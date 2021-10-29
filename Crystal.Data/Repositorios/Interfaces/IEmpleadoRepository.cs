using Crystal.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Data.Repositorios.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> Read();
        Task<Empleado> ReadOne(int id);
        Task<int> Create(Empleado emp);
        Task CreateDir(Direccion dir);
    }
}
