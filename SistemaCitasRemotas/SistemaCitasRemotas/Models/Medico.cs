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
    using System.Linq;
    [Table("Medico")]
    public partial class Medico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medico()
        {
            Cita = new HashSet<Cita>();
            Receta = new HashSet<Receta>();
        }

        public int id { get; set; }

        public int idTipoUsuario { get; set; }

        public int idEspecialidad { get; set; }

        [StringLength(150)]
        public string nombres { get; set; }

        [StringLength(150)]
        public string apellidos { get; set; }

        [StringLength(15)]
        public string telefono { get; set; }

        [StringLength(100)]
        public string correo { get; set; }

        [StringLength(250)]
        public string clave { get; set; }

        [StringLength(50)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }

        public virtual Especialidad Especialidad { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Receta> Receta { get; set; }

        //listar medicos
        public List<Medico> Listar() // retorna varios objetos
        {
            var objMedico = new List<Medico>();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    //sentencia linq
                    objMedico = db.Medico.Include("TipoUsuario").Include("Especialidad").ToList();

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objMedico;
        }

        //obtener medicos
        public Medico Obtener(int id)
        {
            var objMedico = new Medico();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    objMedico = db.Medico
                                .Where(x => x.id == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objMedico;
        }

        //Metodo Autenticar
        public ResponseModel Autenticar(string Correo, string Clave)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    Clave = HashHelper.MD5(Clave);

                    var medico = db.Medico
                        .Where(x => x.correo == Correo)
                        .Where(x => x.clave == Clave)
                        .SingleOrDefault();

                    if (medico != null)
                    {
                        SessionHelper.AddUserToSession(medico.id.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        SessionHelper.DestroyUserSession();
                        rm.SetResponse(false, "Usuario y/o Constraseña incorrectos...");
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return rm;
        }


        public List<Medico> Buscar(string criterioBusqueda)
        {
            var objMedico = new List<Medico>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ModeloRemotas())
                {
                    //SENTENCIAS LINQ
                    objMedico = db.Medico.Include("TipoUsuario")
                        .Where(
                        x => x.nombres.Contains(criterioBusqueda) ||
                        x.apellidos.Equals(criterioBusqueda) 
                        ).ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objMedico;

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
