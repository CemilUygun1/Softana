using Microsoft.EntityFrameworkCore;
using Softana.Models;

namespace Softana.Context
{
    public class SoftanaContext : DbContext
    {
        //public SoftanaContext(DbContextOptions options):base(options)
        //{
        //}
        public SoftanaContext(DbContextOptions<SoftanaContext> options) : base(options)
        {
        }

        public virtual DbSet<Saler> Salers { get; set; }
        public virtual DbSet<SalerDetail> SalerDetails { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=94.73.145.9; Database=u1832976_shopier; User Id=u1832976_cemil; Password= 1.XM87-Z.xdIaz6@; TrustServerCertificate=true");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Saler>(entity =>
            {
                entity.ToTable("Saler");

                entity.HasKey(e => e.SalerId);

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.Ddate)
                    .HasColumnType("datetime")
                    .HasColumnName("DDate");

                entity.Property(e => e.Udate)
                   .HasColumnType("datetime")
                   .HasColumnName("UDate");

                entity.Property(e => e.Duser)
                    .HasMaxLength(100)
                    .HasColumnName("DUser");

                entity.Property(e => e.Cuser)
                   .HasMaxLength(100)
                   .HasColumnName("CUser");

                entity.Property(e => e.Uuser)
                  .HasMaxLength(100)
                  .HasColumnName("UUser");

                entity.HasOne(d => d.SalerDetails)
                    .WithMany(p => p.Salers)
                    .HasForeignKey(d => d.SalerId)
                    .HasConstraintName("FK_Saler_SalerDetail");
            });
        }
    }
}