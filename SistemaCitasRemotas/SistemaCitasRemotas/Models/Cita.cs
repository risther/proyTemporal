namespace SistemaCitasRemotas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;


    [Table("Cita")]
    public partial class Cita
    {
        public int id { get; set; }

        public int idUsuario { get; set; }

        public int idMedico { get; set; }

        [StringLength(50)]
        public string tipoCita { get; set; }

        [StringLength(30)]
        public string estadoCita { get; set; }

        public DateTime? inicio { get; set; }

        public DateTime? fin { get; set; }

        [StringLength(200)]
        public string link { get; set; }

        public int? idHistoria { get; set; }

        public virtual Historia Historia { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual Usuario Usuario { get; set; }


        public List<Cita> Listar() // retorna varios objetos
        {
            var objCita = new List<Cita>();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    //sentencia linq
                    objCita = db.Cita.Include("Usuario").Include("Medico").ToList();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return objCita;
        }

        public Cita Obtener(int id) //retorna solo un objeto
        {
            var objCita = new Cita();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    //sentencia linq
                    objCita = db.Cita.Include("Usuario").Include("Medico")
                                    .Where(x => x.id == id)
                                    .SingleOrDefault();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return objCita;
        }
        //metodo buscar
        public List<Cita> Buscar(string criterio) // retorna varios objetos
        {
            var objCita = new List<Cita>();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    //sentencia linq
                    objCita = db.Cita.Include("Usuario").Include("Medico")
                                    .Where(x => x.Usuario.nombres.Contains(criterio)
                                    || x.id.ToString().Equals(criterio))
                                    .ToList();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return objCita;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModeloRemotas())
                {
                    if (this.id > 0) // si es mayor que 0 es porque existe el ID
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

        //Metodo Eliminar
        public void Eliminar()
        {
            try
            {
                using (var db = new ModeloRemotas())
                {
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
