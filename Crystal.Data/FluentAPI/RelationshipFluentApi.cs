using Crystal.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Crystal.Data.FluentAPI
{
    public static class RelationshipFluentApi
    {
        public static void RelationshioFluentAPI(this ModelBuilder modelBuilder)
        {
            #region Relaciones_Entre_Entidades
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
