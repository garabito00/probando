using Crystal.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Crystal.Data.FluentAPI
{
    public static class DireccionFluentApi
    {
        public static void DireccionFluentAPI(this ModelBuilder modelBuilder)
        {

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

        }
    }
}
