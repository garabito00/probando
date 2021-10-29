using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.AppService.Servicios.interfaces
{
    public interface IGenericService<T>
    {
        Task Crear(T model);
        Task<IEnumerable<T>> Leer();
        Task<T> LeerUno(int id);
        Task Actualizar(int id, T model);
        Task Borrar(int id);
    }
}
