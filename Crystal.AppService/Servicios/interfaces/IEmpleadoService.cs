using Crystal.Domain.Entidades;
using Crystal.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.AppService.Servicios.interfaces
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> Leer();
        Task<Empleado> LeerUno(int id);
        Task Crear(EmpleadoViewModel emp);
    }
}
