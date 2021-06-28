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
    [Table("Especialidad")]
    public partial class Especialidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Especialidad()
        {
            HorarioDia = new HashSet<HorarioDia>();
            Medico = new HashSet<Medico>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(250)]
        public string descripcion { get; set; }

        [StringLength(12)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorarioDia> HorarioDia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medico> Medico { get; set; }

        public List<Especialidad> Listar() // retorna varios objetos
        {
            var objUsuario = new List<Especialidad>();

            try
            {
                using (var db = new ModeloRemotas())
                {
                    //sentencia linq
                    objUsuario = db.Especialidad.ToList();

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
