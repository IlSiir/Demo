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
                entity.HasKey(e => e.Päivämäärä);

                entity.Property(e => e.Päivämäärä).HasColumnType("date");

                entity.Property(e => e.Kuukausi)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Perusharjoitukset>(entity =>
            {
                entity.HasKey(e => e.Päivämäärä);

                entity.Property(e => e.Päivämäärä).HasColumnType("date");

                entity.Property(e => e.Kuukausi)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Punttiennosto>(entity =>
            {
                entity.HasKey(e => e.Päivämäärä);

                entity.Property(e => e.Päivämäärä).HasColumnType("date");

                entity.Property(e => e.Kuukausi)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
