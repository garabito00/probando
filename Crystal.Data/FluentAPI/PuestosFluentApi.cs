using Crystal.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Crystal.Data.FluentAPI
{
    public static class PuestosFluentApi
    {
        public static void PuestosFluentAPI(this ModelBuilder modelBuilder)
        {

            #region Entidad_Puestos
            //Configurar la entidad de Direccion
            modelBuilder.Entity<Puesto>().ToTable("puesto");

            //Configurar la llave primarea
            modelBuilder.Entity<Puesto>().HasKey(p => p.ID);

            //configurar las propiedades
            modelBuilder.Entity<Puesto>().Property(p => p.Rol).HasColumnName("Rol").HasColumnType("Varchar").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Puesto>().Property(p => p.Sueldo).HasColumnName("Sueldo").HasColumnType("decimal").IsRequired();

            #endregion

        }
    }
}
