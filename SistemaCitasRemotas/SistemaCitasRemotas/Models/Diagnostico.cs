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
    [Table("Diagnostico")]
    public partial class Diagnostico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diagnostico()
        {
            Historia = new HashSet<Historia>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string codigo { get; set; }

        [StringLength(150)]
        public string nombre { get; set; }

        [StringLength(500)]
        public string descripcion { get; set; }

        [StringLength(12)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historia> Historia { get; set; }

        public List<Diagnostico> Listar() // retorna varios objetos
        {
            var objDiagnostico = new List<Diagnostico>();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    //sentencia linq
                    objDiagnostico = db.Diagnostico.Include("Historia").ToList();

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objDiagnostico;
        }
        public List<Diagnostico> ListarDiadnosticoMedico(int id)
        {
            var objDiagnostico = new List<Diagnostico>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ModeloRemotas())
                {
                    //SENTENCIAS LINQ
                    //objDiagnostico = db.Diagnostico.Include("Historia").Include("Usuario")
                    //    .Where(x => x.nombre == Historia.)
                    //    .ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objDiagnostico;

        }

        public List<Diagnostico> ListarDiagnosticoCliente(string nombre)
        {
            var objDiagnostico = new List<Diagnostico>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ModeloRemotas())
                {
                    //SENTENCIAS LINQ
                    objDiagnostico = db.Diagnostico
                        .Where(x => x.nombre == nombre)
                        .ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objDiagnostico;

        }
        //obtener usuario
        public Diagnostico Obtener(int id)
        {
            var objDiagnostico = new Diagnostico();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    objDiagnostico = db.Diagnostico
                                .Where(x => x.id == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objDiagnostico;
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
