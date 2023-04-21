using System;
using System.Collections.Generic;
using System.Data;
using Api.Peliculas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Peliculas.Data;

public partial class PeliculasContext : DbContext
{
    public PeliculasContext()
    {
    }

    public PeliculasContext(DbContextOptions<PeliculasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GeneroPelicula> GeneroPeliculas { get; set; }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<PeliculaxGenero> PeliculaxGeneros { get; set; }

    public virtual DbSet<PreferenciaUsuario> PreferenciaUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Name=Peliculas");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<GeneroPelicula>(entity =>
        {
            entity.HasKey(e => e.IdGeneroPelicula).HasName("pk_GeneroPelicula");

            entity.ToTable("GeneroPelicula");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.IdPelicula).HasName("pk_Pelicula");

            entity.ToTable("Pelicula");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Sinopsis).IsUnicode(false);
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PeliculaxGenero>(entity =>
        {
            entity.HasKey(e => e.IdPeliculaxGenero).HasName("pk_PeliculaxGenero");

            entity.ToTable("PeliculaxGenero");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdGeneroPeliculaNavigation).WithMany(p => p.PeliculaxGeneros)
                .HasForeignKey(d => d.IdGeneroPelicula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_PeliculaxGenero_GeneroPelicula");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.PeliculaxGeneros)
                .HasForeignKey(d => d.IdPelicula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_PeliculaxGenero_Pelicula");
        });

        modelBuilder.Entity<PreferenciaUsuario>(entity =>
        {
            entity.HasKey(e => e.IdPreferenciaUsuario).HasName("pk_PreferenciaUsuario");

            entity.ToTable("PreferenciaUsuario");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdGeneroPeliculaNavigation).WithMany(p => p.PreferenciaUsuarios)
                .HasForeignKey(d => d.IdGeneroPelicula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PreferenciaUsuario_GeneroPelicula");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.PreferenciaUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PreferenciaUsuario_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("pk_Usuario");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.UserName, "un_Usuario").IsUnique();

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Fechacreacion).HasColumnType("datetime");
            entity.Property(e => e.PassWord)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuarioRegistradoDataSet>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<ItemDesplegableDataSet>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<PeliculaDataSet>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<UsuarioInsertDataSet>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<DataSet>(entity =>
        {
            entity.HasNoKey();
        });
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
