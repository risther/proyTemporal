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

    [Table("Dia")]
    public partial class Dia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dia()
        {
            HorarioDia = new HashSet<HorarioDia>();
        }

        public int id { get; set; }

        [Column("dia")]
        [StringLength(11)]
        public string dia1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorarioDia> HorarioDia { get; set; }


      

        public List<Dia> Listar() // retorna varios objetos
        {
            var objDia = new List<Dia>();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    //sentencia linq
                    objDia = db.Dia.Include("HorarioDia").ToList();

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objDia;
        }

        //obtener usuario
        public Dia Obtener(int id)
        {
            var objDia = new Dia();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    objDia = db.Dia
                                .Where(x => x.id == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objDia;
        }

        //Metodo Autenticar
       



        public List<Dia> Buscar(string criterioBusqueda)
        {
            var objDia = new List<Dia>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ModeloRemotas())
                {
                    //SENTENCIAS LINQ
                    objDia = db.Dia.Include("HorarioDia")
                        .Where(
                        x => x.dia1.Contains(criterioBusqueda) 
                        ).ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objDia;

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
