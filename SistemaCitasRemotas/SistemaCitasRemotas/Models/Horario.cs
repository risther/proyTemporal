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
    [Table("Horario")]
    public partial class Horario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Horario()
        {
            HorarioDia = new HashSet<HorarioDia>();
        }

        public int id { get; set; }

        public TimeSpan? inicio { get; set; }

        public TimeSpan? final { get; set; }

        [StringLength(12)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorarioDia> HorarioDia { get; set; }


        public List<Horario> Listar() // retorna varios objetos
        {
            var objHorario = new List<Horario>();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    //sentencia linq
                    objHorario = db.Horario.Include("HorarioDia").ToList();

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objHorario;
        }

        //obtener usuario
        public Horario Obtener(int id)
        {
            var objHorario = new Horario();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    objHorario = db.Horario
                                .Where(x => x.id == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objHorario;
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
