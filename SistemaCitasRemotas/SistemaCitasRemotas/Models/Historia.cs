namespace SistemaCitasRemotas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    using System.Web;
    using System.Data.Entity.Validation;
    using System.IO;

    [Table("Historia")]
    public partial class Historia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Historia()
        {
            Cita = new HashSet<Cita>();
        }

        public int id { get; set; }

        public int idUsuario { get; set; }

        public int idDiagnostico { get; set; }

        public int? idReceta { get; set; }

        [StringLength(500)]
        public string detalles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }

        public virtual Diagnostico Diagnostico { get; set; }

        public virtual Usuario Usuario { get; set; }

        public List<Historia> Listar() // retorna varios objetos
        {
            var objHistoria = new List<Historia>();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    //sentencia linq
                    objHistoria = db.Historia.Include("Usuario").Include("Diagnostico").ToList();

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objHistoria;
        }
        public List<Historia> VerHistoriaID(int id) // retorna varios objetos
        {
            var objHistoria = new List<Historia>();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    //sentencia linq
                    objHistoria = db.Historia.Include("Usuario").Include("Diagnostico")
                         .Where(x => x.id == id).ToList();

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objHistoria;
        }

        //obtener usuario
        public Historia Obtener(int id)
        {
            var objHistoria = new Historia();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    objHistoria = db.Historia
                                .Where(x => x.id == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objHistoria;
        }

        //Metodo Autenticar




        //public List<Horario> Buscar(string criterioBusqueda)
        //{
        //    var objHorario = new List<Horario>();
        //    try
        //    {
        //        //ORIGEN DE DATOS
        //        using (var db = new ModeloRemotas())
        //        {
        //            //SENTENCIAS LINQ
        //            objHorario = db.Horario.Include("HorarioDia")
        //                .Where(
        //                x => x.inicio.Contains(criterioBusqueda) ||
        //                 x.final.Contains(criterioBusqueda)
        //                ).ToList();
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //    return objHorario;

        //}

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
