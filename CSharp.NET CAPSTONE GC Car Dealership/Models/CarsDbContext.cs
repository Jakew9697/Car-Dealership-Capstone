using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSharp.NET_CAPSTONE_GC_Car_Dealership.Models
{
    public partial class CarsDbContext : DbContext
    {
        public CarsDbContext()
        {
        }

        public CarsDbContext(DbContextOptions<CarsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarInfo> CarInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=CarsDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarInfo>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.Make).HasMaxLength(25);

                entity.Property(e => e.Model).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
