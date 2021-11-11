using Crystal.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Crystal.Data.FluentAPI
{
    public static class DepartamentoFluentApi
    {
        public static void DepartamentoFluentAPI(this ModelBuilder modelBuilder)
        {

            #region Entidad_Departamento
            //Configurar la entidad de Direccion
            modelBuilder.Entity<Departamento>().ToTable("departamento");

            //Configurar la llave primarea
            modelBuilder.Entity<Departamento>().HasKey(d => d.ID);

            //configurar las propiedades
            modelBuilder.Entity<Departamento>().Property(p => p.Nombre).HasColumnName("Nombre").HasColumnType("Varchar").HasMaxLength(20).IsRequired();

            #endregion

        }
    }
}
