using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Eszaki_kozephegyseg_kilatoi_GUI.Models;

public partial class NcmviewpointsContext : DbContext
{
    public NcmviewpointsContext()
    {
    }

    public NcmviewpointsContext(DbContextOptions<NcmviewpointsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Viewpoint> Viewpoints { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseMySql("server=localhost;database=ncmviewpoints;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.22-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_hungarian_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("locations");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Location1)
                .HasMaxLength(30)
                .HasColumnName("location");
        });

        modelBuilder.Entity<Viewpoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("viewpoints");

            entity.HasIndex(e => e.Location, "FK_viewpoints_location");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Built).HasColumnName("built");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Height)
                .HasColumnType("double(5,2)")
                .HasColumnName("height");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(50)
                .HasColumnName("imageUrl");
            entity.Property(e => e.Location)
                .HasColumnType("int(11)")
                .HasColumnName("location");
            entity.Property(e => e.Mountain)
                .HasMaxLength(30)
                .HasColumnName("mountain");
            entity.Property(e => e.ViewpointName)
                .HasMaxLength(50)
                .HasColumnName("viewpointName");

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.Viewpoints)
                .HasForeignKey(d => d.Location)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_viewpoints_location");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
