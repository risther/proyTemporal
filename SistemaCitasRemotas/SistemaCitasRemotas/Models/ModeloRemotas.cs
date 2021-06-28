using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SistemaCitasRemotas.Models
{
    public partial class ModeloRemotas : DbContext
    {
        public ModeloRemotas()
            : base("name=ModeloRemotas")
        {
        }

        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Dia> Dia { get; set; }
        public virtual DbSet<Diagnostico> Diagnostico { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Historia> Historia { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<HorarioDia> HorarioDia { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Receta> Receta { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>()
                .Property(e => e.tipoCita)
                .IsUnicode(false);

            modelBuilder.Entity<Cita>()
                .Property(e => e.estadoCita)
                .IsUnicode(false);

            modelBuilder.Entity<Cita>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<Dia>()
                .Property(e => e.dia1)
                .IsUnicode(false);

            modelBuilder.Entity<Dia>()
                .HasMany(e => e.HorarioDia)
                .WithRequired(e => e.Dia)
                .HasForeignKey(e => e.idDia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Diagnostico>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostico>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostico>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostico>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostico>()
                .HasMany(e => e.Historia)
                .WithRequired(e => e.Diagnostico)
                .HasForeignKey(e => e.idDiagnostico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Especialidad>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Especialidad>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Especialidad>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Especialidad>()
                .HasMany(e => e.HorarioDia)
                .WithRequired(e => e.Especialidad)
                .HasForeignKey(e => e.idEspecialidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Especialidad>()
                .HasMany(e => e.Medico)
                .WithRequired(e => e.Especialidad)
                .HasForeignKey(e => e.idEspecialidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Historia>()
                .Property(e => e.detalles)
                .IsUnicode(false);

            modelBuilder.Entity<Historia>()
                .HasMany(e => e.Cita)
                .WithOptional(e => e.Historia)
                .HasForeignKey(e => e.idHistoria);

            modelBuilder.Entity<Horario>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .HasMany(e => e.HorarioDia)
                .WithRequired(e => e.Horario)
                .HasForeignKey(e => e.idHorario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Medico)
                .HasForeignKey(e => e.idMedico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.Receta)
                .WithRequired(e => e.Medico)
                .HasForeignKey(e => e.idMedico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Receta>()
                .Property(e => e.indicaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Receta>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<TipoUsuario>()
                .Property(e => e.nombre)
                .IsFixedLength();

            modelBuilder.Entity<TipoUsuario>()
                .HasMany(e => e.Medico)
                .WithRequired(e => e.TipoUsuario)
                .HasForeignKey(e => e.idTipoUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoUsuario>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.TipoUsuario)
                .HasForeignKey(e => e.idTipoUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.idUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Historia)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.idUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Receta)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.idUsuario)
                .WillCascadeOnDelete(false);
        }
    }
}
