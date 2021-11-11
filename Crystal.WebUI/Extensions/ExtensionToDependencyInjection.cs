using Crystal.AppService.Servicios.Implementacion;
using Crystal.AppService.Servicios.interfaces;
using Crystal.Data.Repositorios.Implementacion;
using Crystal.Data.Repositorios.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crystal.WebUI.Extensions
{
    public static class ExtensionToDependencyInjection
    {
        public static void Inyecciones(this IServiceCollection services)
        {
            #region Inyeccion_De_Repositorios
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IDepartamentoRepository), typeof(DepartamentoRepository));
            #endregion

            #region Inyeccion_De_Servicios
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped(typeof(IDepartamentoService), typeof(DepartamentoService));

            services.AddScoped(typeof(IPuestoRepository), typeof(PuestoRepository));
            services.AddScoped(typeof(IPuestoService), typeof(PuestoService));

            services.AddScoped(typeof(IEmpleadoRepository), typeof(EmpleadoRepository));
            services.AddScoped(typeof(IEmpleadoService), typeof(EmpleadoService));
            #endregion
        }
    }
}
