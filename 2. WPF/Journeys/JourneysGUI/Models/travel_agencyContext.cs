using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JourneysGUI.Models
{
    public partial class travel_agencyContext : DbContext
    {
        public travel_agencyContext()
        {
        }

        public travel_agencyContext(DbContextOptions<travel_agencyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JourneyModel> Journeys { get; set; } = null!;
        public virtual DbSet<VehicleModel> Vehicles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user id=root;database=utazasok", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.22-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_hungarian_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<JourneyModel>(entity =>
            {
                entity.ToTable("journeys");

                entity.UseCollation("utf8mb4_hungarian_ci");

                entity.HasIndex(e => e.Vehicle, "journeys_vehicle_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Capacity)
                    .HasColumnType("int(11)")
                    .HasColumnName("capacity")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .HasColumnName("country");

                entity.Property(e => e.Departure)
                    .HasColumnName("departure");

                entity.Property(e => e.Description)
                    .HasColumnName("description");

                entity.Property(e => e.Vehicle)
                    .HasColumnType("int(11)")
                    .HasColumnName("vehicle");

                entity.HasOne(d => d.VehicleNavigation)
                    .WithMany(p => p.Journeys)
                    .HasForeignKey(d => d.Vehicle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("journeys_vehicle_foreign");
            });

            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.ToTable("vehicles");

                entity.UseCollation("utf8mb4_hungarian_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .HasColumnName("type");
                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
