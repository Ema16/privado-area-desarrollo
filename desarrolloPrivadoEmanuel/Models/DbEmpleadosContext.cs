using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace desarrolloPrivadoEmanuel.Models;

public partial class DbEmpleadosContext : DbContext
{
    public DbEmpleadosContext()
    {
    }

    public DbEmpleadosContext(DbContextOptions<DbEmpleadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contiene> Contienes { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<HistorialIncremento> HistorialIncrementos { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<TrabajaEn> TrabajaEns { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySQL("Server=192.168.99.100;port=3306;Database=DB_Empleados;Uid=emanuel;Pwd=emanuel.amperez;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contiene>(entity =>
        {
            entity.HasKey(e => e.CodEmpresaDepartamento).HasName("PRIMARY");

            entity.ToTable("Contiene");

            entity.HasIndex(e => e.CodDepartamento, "RefDepartamento7");

            entity.HasIndex(e => e.CodEmpresa, "RefEmpresa13");

            entity.HasIndex(e => e.CodPuesto, "RefPuesto8");

            entity.Property(e => e.CodEmpresaDepartamento).HasColumnName("cod_empresa_departamento");
            entity.Property(e => e.CodDepartamento).HasColumnName("cod_departamento");
            entity.Property(e => e.CodEmpresa).HasColumnName("cod_empresa");
            entity.Property(e => e.CodPuesto).HasColumnName("cod_puesto");
            entity.Property(e => e.PagoPuesto)
                .HasPrecision(10)
                .HasColumnName("pago_puesto");

            entity.HasOne(d => d.CodDepartamentoNavigation).WithMany(p => p.Contienes)
                .HasForeignKey(d => d.CodDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefDepartamento7");

            entity.HasOne(d => d.CodEmpresaNavigation).WithMany(p => p.Contienes)
                .HasForeignKey(d => d.CodEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefEmpresa13");

            entity.HasOne(d => d.CodPuestoNavigation).WithMany(p => p.Contienes)
                .HasForeignKey(d => d.CodPuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefPuesto8");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.CodContrato).HasName("PRIMARY");

            entity.ToTable("Contrato");

            entity.HasIndex(e => e.CodEmpleado, "RefEmpleado3");

            entity.HasIndex(e => e.CodEmpresa, "RefEmpresa4");

            entity.Property(e => e.CodContrato).HasColumnName("cod_contrato");
            entity.Property(e => e.CodEmpleado).HasColumnName("cod_empleado");
            entity.Property(e => e.CodEmpresa).HasColumnName("cod_empresa");
            entity.Property(e => e.FechaContrato)
                .HasColumnType("date")
                .HasColumnName("fecha_contrato");

            entity.HasOne(d => d.CodEmpleadoNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.CodEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefEmpleado3");

            entity.HasOne(d => d.CodEmpresaNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.CodEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefEmpresa4");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.CodDepartamento).HasName("PRIMARY");

            entity.ToTable("Departamento");

            entity.Property(e => e.CodDepartamento).HasColumnName("cod_departamento");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(150)
                .HasColumnName("nombre_departamento");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.CodEmpleado).HasName("PRIMARY");

            entity.ToTable("Empleado");

            entity.HasIndex(e => e.CodPuesto, "RefPuesto12");

            entity.Property(e => e.CodEmpleado).HasColumnName("cod_empleado");
            entity.Property(e => e.CodPuesto).HasColumnName("cod_puesto");
            entity.Property(e => e.EstadoAntiguedad)
                .HasMaxLength(50)
                .HasColumnName("estado_antiguedad");
            entity.Property(e => e.EstadoContrato)
                .HasMaxLength(50)
                .HasColumnName("estado_contrato");
            entity.Property(e => e.EstadoEmpleado)
                .HasMaxLength(50)
                .HasColumnName("estado_empleado");
            entity.Property(e => e.FechaContrato)
                .HasColumnType("date")
                .HasColumnName("fecha_contrato");
            entity.Property(e => e.FechaInicioContrato)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio_contrato");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(250)
                .HasColumnName("nombre_empleado");
            entity.Property(e => e.NuevoSueldo)
                .HasPrecision(10)
                .HasColumnName("nuevo_sueldo");
            entity.Property(e => e.SueldoBase)
                .HasPrecision(10)
                .HasColumnName("sueldo_base");
            entity.Property(e => e.TelefonoEmpleado)
                .HasMaxLength(15)
                .HasColumnName("telefono_empleado");

            entity.HasOne(d => d.CodPuestoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CodPuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefPuesto12");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.CodEmpresa).HasName("PRIMARY");

            entity.ToTable("Empresa");

            entity.Property(e => e.CodEmpresa).HasColumnName("cod_empresa");
            entity.Property(e => e.DireccionEmpresa)
                .HasMaxLength(150)
                .HasColumnName("direccion_empresa");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(150)
                .HasColumnName("nombre_empresa");
            entity.Property(e => e.TelefonoEmpresa)
                .HasMaxLength(50)
                .HasColumnName("telefono_empresa");
        });

        modelBuilder.Entity<HistorialIncremento>(entity =>
        {
            entity.HasKey(e => e.CodHistorialIncremento).HasName("PRIMARY");

            entity.ToTable("Historial_Incremento");

            entity.HasIndex(e => e.CodEmpleado, "RefEmpleado11");

            entity.Property(e => e.CodHistorialIncremento).HasColumnName("cod_historial_incremento");
            entity.Property(e => e.CodEmpleado).HasColumnName("cod_empleado");
            entity.Property(e => e.FechaAumento)
                .HasColumnType("date")
                .HasColumnName("fecha_aumento");
            entity.Property(e => e.NuevoSaldo)
                .HasPrecision(10)
                .HasColumnName("nuevo_saldo");
            entity.Property(e => e.PorcentajeAumento)
                .HasPrecision(10)
                .HasColumnName("porcentaje_aumento");
            entity.Property(e => e.SaldoAnterior)
                .HasPrecision(10)
                .HasColumnName("saldo_anterior");
            entity.Property(e => e.SaldoBase)
                .HasPrecision(10)
                .HasColumnName("saldo_base");

            entity.HasOne(d => d.CodEmpleadoNavigation).WithMany(p => p.HistorialIncrementos)
                .HasForeignKey(d => d.CodEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefEmpleado11");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.CodPuesto).HasName("PRIMARY");

            entity.ToTable("Puesto");

            entity.Property(e => e.CodPuesto).HasColumnName("cod_puesto");
            entity.Property(e => e.NombrePuesto)
                .HasMaxLength(150)
                .HasColumnName("nombre_puesto");
            entity.Property(e => e.PagoPuesto)
                .HasPrecision(10)
                .HasColumnName("pago_puesto");
        });

        modelBuilder.Entity<TrabajaEn>(entity =>
        {
            entity.HasKey(e => e.CodEmpleadoDepartamento).HasName("PRIMARY");

            entity.ToTable("Trabaja_En");

            entity.HasIndex(e => e.CodDepartamento, "RefDepartamento6");

            entity.HasIndex(e => e.CodEmpleado, "RefEmpleado5");

            entity.Property(e => e.CodEmpleadoDepartamento).HasColumnName("cod_empleado_departamento");
            entity.Property(e => e.CodDepartamento).HasColumnName("cod_departamento");
            entity.Property(e => e.CodEmpleado).HasColumnName("cod_empleado");

            entity.HasOne(d => d.CodDepartamentoNavigation).WithMany(p => p.TrabajaEns)
                .HasForeignKey(d => d.CodDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefDepartamento6");

            entity.HasOne(d => d.CodEmpleadoNavigation).WithMany(p => p.TrabajaEns)
                .HasForeignKey(d => d.CodEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefEmpleado5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
