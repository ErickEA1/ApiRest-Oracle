using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OracleDDD.Domain.Entities;

namespace OracleDDD.Infraestructure.Context;

public partial class ContextoDatos : DbContext
{
    public ContextoDatos()
    {
    }

    public ContextoDatos(DbContextOptions<ContextoDatos> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> PRODUCTOS { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseOracle("User Id=USUARIO_ERICK;Password=Escobar333;Data Source=localhost:1521/ORCL;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
           .HasDefaultSchema("USUARIO_ERICK")
           .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRODUCTOS_PK");

            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CATEGORIA");
            entity.Property(e => e.Codigobarras)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CODIGOBARRAS");
            entity.Property(e => e.Nombreproducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBREPRODUCTO");
            entity.Property(e => e.Precio)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Stock)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("STOCK");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasColumnName("URLIMAGEN");
            entity.Property(e => e.Descripcion)
               .HasMaxLength(1000)
               .IsUnicode(false)
               .HasColumnName("DESCRIPCION");
        });
        modelBuilder.HasSequence("AUTOINCREMENTO");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
