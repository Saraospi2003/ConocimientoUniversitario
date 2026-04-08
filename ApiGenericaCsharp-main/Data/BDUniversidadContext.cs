using System;
using System.Collections.Generic;
using ApiGenericaCsharp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Data;

public partial class BDUniversidadContext : DbContext
{
    public BDUniversidadContext()
    {
    }

    public BDUniversidadContext(DbContextOptions<BDUniversidadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aliado> Aliados { get; set; }

    public virtual DbSet<AspectoNormativo> AspectoNormativos { get; set; }

    public virtual DbSet<CarInnovacion> CarInnovacions { get; set; }

    public virtual DbSet<Enfoque> Enfoques { get; set; }

    public virtual DbSet<PracticaEstrategium> PracticaEstrategia { get; set; }

    public virtual DbSet<Universidad> Universidads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=OFICINA\\MSSQLSERVER01;Database=BDUniversidad;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aliado>(entity =>
        {
            entity.HasKey(e => e.Nit).HasName("PK__aliado__DF97D0E51D01DE68");

            entity.ToTable("aliado");

            entity.Property(e => e.Nit)
                .ValueGeneratedNever()
                .HasColumnName("nit");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(45)
                .HasColumnName("ciudad");
            entity.Property(e => e.Correo)
                .HasMaxLength(70)
                .HasColumnName("correo");
            entity.Property(e => e.NombreContacto)
                .HasMaxLength(60)
                .HasColumnName("nombre_contacto");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(60)
                .HasColumnName("razon_social");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<AspectoNormativo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__aspecto___3213E83F5DEBBE9A");

            entity.ToTable("aspecto_normativo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fuente)
                .HasMaxLength(45)
                .HasColumnName("fuente");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<CarInnovacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__car_inno__3213E83F7DECCFC1");

            entity.ToTable("car_innovacion");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Enfoque>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__enfoque__3213E83F45B42215");

            entity.ToTable("enfoque");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<PracticaEstrategium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__practica__3213E83F393D3610");

            entity.ToTable("practica_estrategia");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Universidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__universi__3213E83FB94E6FC7");

            entity.ToTable("universidad");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(45)
                .HasColumnName("ciudad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
