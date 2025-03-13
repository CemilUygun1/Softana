using Microsoft.EntityFrameworkCore;
using Softana.Models;

namespace Softana.Context
{
    public class SoftanaContext : DbContext
    {
        //public SoftanaContext(DbContextOptions<SoftanaContext> options):base(options)
        //{
        //}
        public SoftanaContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=94.73.145.9; Database=u1832976_shopier; User Id=u1832976_cemil; Password= 1.XM87-Z.xdIaz6@; TrustServerCertificate=true");
            }
        }

        public DbSet<Saler> Salers { get; set; }
        public DbSet<SalerDetail> SalerDetails { get; set; }
    }
}
