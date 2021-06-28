namespace SistemaCitasRemotas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Receta")]
    public partial class Receta
    {
        public int id { get; set; }

        public int idUsuario { get; set; }

        public int idMedico { get; set; }

        public DateTime? fecha { get; set; }

        [StringLength(500)]
        public string indicaciones { get; set; }

        [StringLength(12)]
        public string estado { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual Usuario Usuario { get; set; }



        public List<Receta> Listar()
        {
            var objUsuario = new List<Receta>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ModeloRemotas())
                {
                    //SENTENCIAS LINQ
                    objUsuario = (db.Receta.Include("Medico").Include("Usuario")).ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objUsuario;

        }

        public List<Receta> ListarRecetaMedico(int id)
        {
            var objReceta = new List<Receta>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ModeloRemotas())
                {
                    //SENTENCIAS LINQ
                    objReceta =  db.Receta.Include("Medico").Include("Usuario")
                        .Where(x => x.idMedico == id)
                        .ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objReceta;

        }

        public List<Receta> ListarRecetaCliente(int id)
        {
            var objReceta = new List<Receta>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ModeloRemotas())
                {
                    //SENTENCIAS LINQ
                    objReceta = db.Receta.Include("Medico").Include("Usuario")
                        .Where(x => x.Usuario.id == id)
                        .ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objReceta;

        }


        //Obtener
        public Receta Obtener(int id)
        {
            var objUsuario = new Receta();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ModeloRemotas())
                {
                    //SENTENCIAS LINQ
                    objUsuario = db.Receta.Include("Medico").Include("Usuario")
                        .Where(x => x.id == id)
                        .SingleOrDefault();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objUsuario;

        }

        public List<Receta> Buscar(string criterioBusqueda)
        {
            var objUsuario = new List<Receta>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ModeloRemotas())
                {
                    //SENTENCIAS LINQ
                    objUsuario = db.Receta.Include("Medico").Include("Usuario")
                        .Where(
                        x => x.Medico.nombres.Contains(criterioBusqueda)||
                        x.Medico.nombres.Contains(criterioBusqueda)
                        ).ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objUsuario;

        }

        public void Guardar()
        {
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ModeloRemotas())
                {
                    //SENTENCIAS LINQ
                    if (this.id > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //ELIMINAR

        public void Eliminar()
        {
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ModeloRemotas())
                {
                    //SENTENCIAS LINQ

                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
