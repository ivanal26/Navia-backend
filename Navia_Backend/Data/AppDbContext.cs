using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Navia_Backend.Data.Models;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Navia_Backend.Data;

public partial class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public virtual DbSet<Marker> Markers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Marker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("markers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChangedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("changed_at");
            entity.Property(e => e.ChangedBy)
                .HasMaxLength(50)
                .HasColumnName("changed_by");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Latitud).HasColumnName("latitud");
            entity.Property(e => e.Longitud).HasColumnName("longitud");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Valoracion)
                .HasDefaultValueSql("'0'")
                .HasColumnName("valoracion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
