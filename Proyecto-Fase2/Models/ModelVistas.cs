namespace Proyecto_Fase2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelVistas : DbContext
    {
        public ModelVistas()
            : base("name=ModelVistas1")
        {
        }

        public virtual DbSet<CxC30> CxC30 { get; set; }
        public virtual DbSet<CxC60> CxC60 { get; set; }
        public virtual DbSet<CxC90> CxC90 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CxC30>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CxC30>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CxC60>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CxC60>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CxC90>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CxC90>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);
        }
    }
}
