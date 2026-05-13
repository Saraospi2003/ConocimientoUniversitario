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

    public virtual DbSet<AreaConocimiento> AreaConocimientos { get; set; }
    public virtual DbSet<Facultad> Facultads { get; set; }
    public virtual DbSet<Programa> Programas { get; set; }
    public virtual DbSet<Acreditacion> Acreditacions { get; set; }
    public virtual DbSet<Pasantia> Pasantias { get; set; }
    public virtual DbSet<Premio> Premios { get; set; }
    public virtual DbSet<RegistroCalificado> RegistroCalificados { get; set; }
    public virtual DbSet<ActivAcademica> ActivAcademicas { get; set; }

    public virtual DbSet<ProgramaAc> ProgramaAcs { get; set; }
    public virtual DbSet<ProgramaPe> ProgramaPes { get; set; }
    public virtual DbSet<ProgramaCi> ProgramaCis { get; set; }
    public virtual DbSet<AnPrograma> AnProgramas { get; set; }
    public virtual DbSet<EnfoqueRc> EnfoqueRcs { get; set; }
    public virtual DbSet<AaRc> AaRcs { get; set; }

    public virtual DbSet<Alianza> Alianzas { get; set; }
    public virtual DbSet<DocenteDepartamento> DocenteDepartamentos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
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
            entity.Property(e => e.Descripcion)
                .HasColumnName("descripcion");
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

        modelBuilder.Entity<AreaConocimiento>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("area_conocimiento");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Facultad>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("facultad");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo");
            entity.Property(e => e.FechaIn)
                .HasColumnName("fecha_in");
            entity.Property(e => e.Universidad)
                .HasColumnName("universidad");

            entity.HasOne<Universidad>()
                .WithMany()
                .HasForeignKey(e => e.Universidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_facultad_universidad");
        });

        modelBuilder.Entity<Programa>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("programa");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo");
            entity.Property(e => e.Nivel)
                .HasMaxLength(45)
                .HasColumnName("nivel");
            entity.Property(e => e.FechaCreacion)
                .HasMaxLength(45)
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaCierre)
                .HasMaxLength(45)
                .HasColumnName("fecha_cierre");
            entity.Property(e => e.NumCohortes)
                .HasMaxLength(45)
                .HasColumnName("num_cohortes");
            entity.Property(e => e.CantGraduados)
                .HasMaxLength(45)
                .HasColumnName("cant_graduados");
            entity.Property(e => e.FechaActualizacion)
                .HasMaxLength(45)
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(45)
                .HasColumnName("ciudad");
            entity.Property(e => e.Facultad)
                .HasColumnName("facultad");

            entity.HasOne<Facultad>()
                .WithMany()
                .HasForeignKey(e => e.Facultad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_programa_facultad");
        });

        modelBuilder.Entity<Acreditacion>(entity =>
        {
            entity.HasKey(e => e.Resolucion);

            entity.ToTable("acreditacion");

            entity.Property(e => e.Resolucion)
                .ValueGeneratedNever()
                .HasColumnName("resolucion");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo");
            entity.Property(e => e.Calificacion)
                .HasColumnName("calificacion");
            entity.Property(e => e.FechaInicio)
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaFin)
                .HasColumnName("fecha_fin");
            entity.Property(e => e.ProgramaId)
                .HasColumnName("programa");

            entity.HasOne(e => e.Programa)
                .WithMany()
                .HasForeignKey(e => e.ProgramaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_acreditacion_programa");
        });

        modelBuilder.Entity<Pasantia>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("pasantia");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Pais)
                .HasMaxLength(45)
                .HasColumnName("pais");
            entity.Property(e => e.Empresa)
                .HasMaxLength(45)
                .HasColumnName("empresa");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.Programa)
                .HasColumnName("programa");

            entity.HasOne<Programa>()
                .WithMany()
                .HasForeignKey(e => e.Programa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pasantia_programa");
        });

        modelBuilder.Entity<Premio>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("premio");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasColumnName("fecha");
            entity.Property(e => e.EntidadOtorgante)
                .HasMaxLength(45)
                .HasColumnName("entidad_otorgante");
            entity.Property(e => e.Pais)
                .HasMaxLength(45)
                .HasColumnName("pais");
            entity.Property(e => e.Programa)
                .HasColumnName("programa");

            entity.HasOne<Programa>()
                .WithMany()
                .HasForeignKey(e => e.Programa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_premio_programa");
        });

        modelBuilder.Entity<RegistroCalificado>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("registro_calificado");

            entity.Property(e => e.Codigo)
                .ValueGeneratedNever()
                .HasColumnName("codigo");
            entity.Property(e => e.CantCred)
                .HasMaxLength(45)
                .HasColumnName("cant_cred");
            entity.Property(e => e.HoraAcom)
                .HasMaxLength(45)
                .HasColumnName("hora_acom");
            entity.Property(e => e.HoraInd)
                .HasMaxLength(45)
                .HasColumnName("hora_ind");
            entity.Property(e => e.Metodologia)
                .HasMaxLength(45)
                .HasColumnName("metodologia");
            entity.Property(e => e.FechaInicio)
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaFin)
                .HasColumnName("fecha_fin");
            entity.Property(e => e.DuracionAnios)
                .HasMaxLength(45)
                .HasColumnName("duracion_anios");
            entity.Property(e => e.DuracionSemes)
                .HasMaxLength(45)
                .HasColumnName("duracion_semes");
            entity.Property(e => e.TipoTitulacion)
                .HasMaxLength(45)
                .HasColumnName("tipo_titulacion");
            entity.Property(e => e.Programa)
                .HasColumnName("programa");

            entity.HasOne<Programa>()
                .WithMany()
                .HasForeignKey(e => e.Programa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_registro_programa");
        });

        modelBuilder.Entity<ActivAcademica>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("activ_academica");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.NumCreditos)
                .HasColumnName("num_creditos");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");
            entity.Property(e => e.AreaFormacion)
                .HasMaxLength(45)
                .HasColumnName("area_formacion");
            entity.Property(e => e.HAcom)
                .HasColumnName("h_acom");
            entity.Property(e => e.HIndep)
                .HasColumnName("h_indep");
            entity.Property(e => e.Idioma)
                .HasMaxLength(45)
                .HasColumnName("idioma");
            entity.Property(e => e.Espacio)
                .HasMaxLength(20)
                .HasColumnName("espacio");
            entity.Property(e => e.EntidadApoyo)
                .HasMaxLength(45)
                .HasColumnName("entidad_apoyo");
            entity.Property(e => e.PaisEspejo)
                .HasMaxLength(45)
                .HasColumnName("pais_espejo");
            entity.Property(e => e.Programa)
                .HasColumnName("programa");

            entity.HasOne<Programa>()
                .WithMany()
                .HasForeignKey(e => e.Programa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_activ_programa");
        });

        modelBuilder.Entity<ProgramaAc>(entity =>
        {
            entity.HasKey(e => new { e.Programa, e.AreaConocimiento });

            entity.ToTable("programa_ac");

            entity.Property(e => e.Programa)
                .HasColumnName("programa");
            entity.Property(e => e.AreaConocimiento)
                .HasColumnName("area_conocimiento");

            entity.HasOne<Programa>()
                .WithMany()
                .HasForeignKey(e => e.Programa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_programa_ac_programa");

            entity.HasOne<AreaConocimiento>()
                .WithMany()
                .HasForeignKey(e => e.AreaConocimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_programa_ac_area");
        });

        modelBuilder.Entity<ProgramaPe>(entity =>
        {
            entity.HasKey(e => new { e.Programa, e.PracticaEstrategia });

            entity.ToTable("programa_pe");

            entity.Property(e => e.Programa)
                .HasColumnName("programa");
            entity.Property(e => e.PracticaEstrategia)
                .HasColumnName("practica_estrategia");

            entity.HasOne<Programa>()
                .WithMany()
                .HasForeignKey(e => e.Programa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_programa_pe_programa");

            entity.HasOne<PracticaEstrategium>()
                .WithMany()
                .HasForeignKey(e => e.PracticaEstrategia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_programa_pe_practica");
        });

        modelBuilder.Entity<ProgramaCi>(entity =>
        {
            entity.HasKey(e => new { e.Programa, e.CarInnovacion });

            entity.ToTable("programa_ci");

            entity.Property(e => e.Programa)
                .HasColumnName("programa");
            entity.Property(e => e.CarInnovacion)
                .HasColumnName("car_innovacion");

            entity.HasOne<Programa>()
                .WithMany()
                .HasForeignKey(e => e.Programa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_programa_ci_programa");

            entity.HasOne<CarInnovacion>()
                .WithMany()
                .HasForeignKey(e => e.CarInnovacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_programa_ci_car_innovacion");
        });

        modelBuilder.Entity<AnPrograma>(entity =>
        {
            entity.HasKey(e => new { e.AspectoNormativo, e.Programa });

            entity.ToTable("an_programa");

            entity.Property(e => e.AspectoNormativo)
                .HasColumnName("aspecto_normativo");
            entity.Property(e => e.Programa)
                .HasColumnName("programa");

            entity.HasOne<AspectoNormativo>()
                .WithMany()
                .HasForeignKey(e => e.AspectoNormativo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_an_programa_aspecto");

            entity.HasOne<Programa>()
                .WithMany()
                .HasForeignKey(e => e.Programa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_an_programa_programa");
        });

        modelBuilder.Entity<EnfoqueRc>(entity =>
        {
            entity.HasKey(e => new { e.Enfoque, e.RegistroCalificado });

            entity.ToTable("enfoque_rc");

            entity.Property(e => e.Enfoque)
                .HasColumnName("enfoque");
            entity.Property(e => e.RegistroCalificado)
                .HasColumnName("registro_calificado");

            entity.HasOne<Enfoque>()
                .WithMany()
                .HasForeignKey(e => e.Enfoque)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_enfoque_rc_enfoque");

            entity.HasOne<RegistroCalificado>()
                .WithMany()
                .HasForeignKey(e => e.RegistroCalificado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_enfoque_rc_registro");
        });

        modelBuilder.Entity<AaRc>(entity =>
        {
            entity.HasKey(e => new { e.ActivAcademica, e.RegistroCalificado });

            entity.ToTable("aa_rc");

            entity.Property(e => e.ActivAcademica)
                .HasColumnName("activ_academica");
            entity.Property(e => e.RegistroCalificado)
                .HasColumnName("registro_calificado");
            entity.Property(e => e.Componente)
                .HasMaxLength(45)
                .HasColumnName("componente");
            entity.Property(e => e.Semestre)
                .HasMaxLength(45)
                .HasColumnName("semestre");

            entity.HasOne<ActivAcademica>()
                .WithMany()
                .HasForeignKey(e => e.ActivAcademica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_aa_rc_activ_academica");

            entity.HasOne<RegistroCalificado>()
                .WithMany()
                .HasForeignKey(e => e.RegistroCalificado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_aa_rc_registro");
        });

        modelBuilder.Entity<Alianza>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("alianza");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.Property(e => e.Departamento)
                .HasColumnName("departamento");

            entity.Property(e => e.FechaInicio)
                .HasColumnName("fecha_inicio");

            entity.Property(e => e.FechaFin)
                .HasColumnName("fecha_fin");

            entity.Property(e => e.Docente)
                .HasColumnName("docente");
        });

        modelBuilder.Entity<DocenteDepartamento>(entity =>
        {
            entity.HasKey(e => new { e.Docente, e.Departamento });

            entity.ToTable("docente_departamento");

            entity.Property(e => e.Docente)
                .HasColumnName("docente");

            entity.Property(e => e.Departamento)
                .HasColumnName("departamento");

            entity.Property(e => e.Dedicacion)
                .HasMaxLength(45)
                .HasColumnName("dedicacion");

            entity.Property(e => e.Modalidad)
                .HasMaxLength(45)
                .HasColumnName("modalidad");

            entity.Property(e => e.FechaIngreso)
                .HasColumnName("fecha_ingreso");

            entity.Property(e => e.FechaSalida)
                .HasColumnName("fecha_salida");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}