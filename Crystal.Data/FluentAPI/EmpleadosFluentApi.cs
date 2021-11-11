using Crystal.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Crystal.Data.FluentAPI
{
    public static class EmpleadosFluentApi
    {
        public static void EmpleadosFluentAPI(this ModelBuilder modelBuilder)
        {

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

        }
    }
}
