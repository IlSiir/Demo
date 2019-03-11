using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorkoutTracker.Database
{
    public partial class WorkoutTrackerContext : DbContext
    {
        public WorkoutTrackerContext()
        {
        }

        public WorkoutTrackerContext(DbContextOptions<WorkoutTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aerobinenharjoitus> Aerobinenharjoitus { get; set; }
        public virtual DbSet<Perusharjoitukset> Perusharjoitukset { get; set; }
        public virtual DbSet<Punttiennosto> Punttiennosto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLExpress;Database=WorkoutTracker;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aerobinenharjoitus>(entity =>
            {
                entity.HasKey(e => e.AeroID);

                entity.Property(e => e.AeroID).HasColumnType("int");

                entity.Property(e => e.Päivämäärä)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Perusharjoitukset>(entity =>
            {
                entity.HasKey(e => e.PerusID);

                entity.Property(e => e.PerusID).HasColumnType("int");

                entity.Property(e => e.Päivämäärä)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Punttiennosto>(entity =>
            {
                entity.HasKey(e => e.PunttiID);

                entity.Property(e => e.PunttiID).HasColumnType("int");

                entity.Property(e => e.Päivämäärä)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
