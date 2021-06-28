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
    [Table("TipoUsuario")]
    public partial class TipoUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoUsuario()
        {
            Medico = new HashSet<Medico>();
            Usuario = new HashSet<Usuario>();
        }

        public int id { get; set; }

        [StringLength(10)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medico> Medico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        public List<TipoUsuario> Listar() // retorna varios objetos
        {
            var objUsuario = new List<TipoUsuario>();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    //sentencia linq
                    objUsuario = db.TipoUsuario.ToList();

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return objUsuario;
        }
    }
}
