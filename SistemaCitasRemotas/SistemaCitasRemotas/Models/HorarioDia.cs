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
    [Table("HorarioDia")]
    public partial class HorarioDia
    {
        public int id { get; set; }

        public int idEspecialidad { get; set; }

        public int idHorario { get; set; }

        public int idDia { get; set; }

        public virtual Dia Dia { get; set; }

        public virtual Especialidad Especialidad { get; set; }

        public virtual Horario Horario { get; set; }

        public List<HorarioDia> Listar() // retorna varios objetos
        {
            var objHorarioDia = new List<HorarioDia>();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    //sentencia linq
                    objHorarioDia = db.HorarioDia.Include("Horario").Include("Dia").Include("Especialidad").ToList();

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objHorarioDia;
        }

        //obtener usuario
        public HorarioDia Obtener(int id)
        {
            var objHorarioDia = new HorarioDia();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    objHorarioDia = db.HorarioDia
                                .Where(x => x.id == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objHorarioDia;
        }

        //Metodo Autenticar




        //public List<HorarioDia> Buscar(string criterioBusqueda)
        //{
        //    var objHorarioDia = new List<HorarioDia>();
        //    try
        //    {
        //        //ORIGEN DE DATOS
        //        using (var db = new ModeloRemotas())
        //        {
        //            //SENTENCIAS LINQ
        //            objHorarioDia = db.HorarioDia.Include("Horario").Include("Dia")
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

        //    return objHorarioDia;

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
