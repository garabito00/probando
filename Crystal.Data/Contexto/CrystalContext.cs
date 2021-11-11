using Crystal.Data.FluentAPI;
using Crystal.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.EmpleadosFluentAPI();

            modelBuilder.DireccionFluentAPI();

            modelBuilder.PuestosFluentAPI();

            modelBuilder.DepartamentoFluentAPI();

            modelBuilder.RelationshioFluentAPI();
        }
    }
}
