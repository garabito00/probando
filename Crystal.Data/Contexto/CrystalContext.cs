using Crystal.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Data.Contexto
{
    public class CrystalContext : DbContext
    {
        public CrystalContext(DbContextOptions<CrystalContext> options) : base(options)
        {

        }

        //Entidades a ser registradas en la base de datos.
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }

        //Crear del Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar el schema
            modelBuilder.HasDefaultSchema("crystal");

            #region Entidad_Empleados
            //Configurar la entidad de Empleado
            modelBuilder.Entity<Empleado>().ToTable("empleados");

                //Configurar la llave primarea
            modelBuilder.Entity<Empleado>().HasKey(e => e.ID);

                //configurar las propiedades
            modelBuilder.Entity<Empleado>().Property(p => p.Nombre).HasColumnName("Nombre").HasColumnType("Varchar").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Empleado>().Property(p => p.Apellido).HasColumnName("Apellido").HasColumnType("Varchar").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Empleado>().Property(p => p.Usuario).HasColumnName("Usuario").HasComputedColumnSql("[Nombre] + '.' + [Apellido]");
            modelBuilder.Entity<Empleado>().Property(p => p.Correo).HasColumnName("Correo").HasComputedColumnSql("[Nombre] + '.' + [Apellido] + '@crystal.com.do'");

            #endregion

            #region Entidad_Direccion
            //Configurar la entidad de Direccion
            modelBuilder.Entity<Direccion>().ToTable("direccion");

            //Configurar la llave primarea
            modelBuilder.Entity<Direccion>().HasKey(d => d.ID);

            //configurar las propiedades
            modelBuilder.Entity<Direccion>().Property(p => p.Calle).HasColumnName("Calle").HasColumnType("Varchar").HasMaxLength(20);
            modelBuilder.Entity<Direccion>().Property(p => p.Ciudad).HasColumnName("Ciudad").HasColumnType("Varchar").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Direccion>().Property(p => p.Pais).HasColumnName("Pais").HasColumnType("Varchar").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Direccion>().Property(p => p.Telefono).HasColumnName("Telefono").HasColumnType("Varchar").HasMaxLength(20);

            #endregion

            #region Entidad_Puestos
            //Configurar la entidad de Direccion
            modelBuilder.Entity<Puesto>().ToTable("puesto");

            //Configurar la llave primarea
            modelBuilder.Entity<Puesto>().HasKey(p => p.ID);

            //configurar las propiedades
            modelBuilder.Entity<Puesto>().Property(p => p.Rol).HasColumnName("Rol").HasColumnType("Varchar").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Puesto>().Property(p => p.Sueldo).HasColumnName("Sueldo").HasColumnType("decimal").IsRequired();

            #endregion

            #region Entidad_Departamento
            //Configurar la entidad de Direccion
            modelBuilder.Entity<Departamento>().ToTable("departamento");

            //Configurar la llave primarea
            modelBuilder.Entity<Departamento>().HasKey(d => d.ID);

            //configurar las propiedades
            modelBuilder.Entity<Departamento>().Property(p => p.Nombre).HasColumnName("Nombre").HasColumnType("Varchar").HasMaxLength(20).IsRequired();

            #endregion

            #region Relaciones_Entre_Entidades
            //Configurar las relaciones
            //Configurar la relacion one-to-may con Empleado a Puestos
            modelBuilder.Entity<Empleado>().HasOne<Puesto>(e => e.Puesto).WithMany(p => p.Empleados).HasForeignKey(e => e.PuestoId);

            //Configurar la relacion one-to-one con Empleado a Direccion
            modelBuilder.Entity<Empleado>().HasOne<Direccion>(e => e.Direccion).WithOne(d => d.Empleado).HasForeignKey<Direccion>(d => d.EmpleadoID);

            //Configurar la relacion one-to-may con Puestos a Departamento
            modelBuilder.Entity<Puesto>().HasOne<Departamento>(p => p.Departamento).WithMany(d => d.Puestos).HasForeignKey(p => p.DepartamentoID);

            #endregion
        }
    }
}
