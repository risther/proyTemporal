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
    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Cita = new HashSet<Cita>();
            Historia = new HashSet<Historia>();
            Receta = new HashSet<Receta>();
        }

        public int id { get; set; }

        public int idTipoUsuario { get; set; }

        [StringLength(50)]
        public string correo { get; set; }

        [StringLength(8)]
        public string dni { get; set; }

        [StringLength(250)]
        public string clave { get; set; }

        [StringLength(50)]
        public string apellidos { get; set; }

        [StringLength(9)]
        public string telefono { get; set; }

        [StringLength(50)]
        public string nombres { get; set; }

        [StringLength(12)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historia> Historia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Receta> Receta { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }


        //metodos para el usuario

        public List<Usuario> Listar() // retorna varios objetos
        {
            var objUsuario = new List<Usuario>();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    //sentencia linq
                    objUsuario = db.Usuario.Include("TipoUsuario").ToList();

                }
            }
            catch (Exception ex)
            {   

                throw;
            }

            return objUsuario;
        }

        //obtener usuario
        public Usuario Obtener(int id)
        {
            var objUsuario = new Usuario();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    objUsuario = db.Usuario
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

   
        //Metodo Autenticar
        public ResponseModel Autenticar(string Correo, string Clave)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    Clave = HashHelper.MD5(Clave);

                    var usuario = db.Usuario
                        .Where(x => x.correo == Correo)
                        .Where(x => x.clave == Clave)
                        .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.id.ToString());
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



        public List<Usuario> Buscar(string criterioBusqueda)
        {
            var objUsuario = new List<Usuario>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ModeloRemotas())
                {
                    //SENTENCIAS LINQ
                    objUsuario = db.Usuario.Include("TipoUsuario")
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
