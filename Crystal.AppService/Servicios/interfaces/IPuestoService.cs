using Crystal.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.AppService.Servicios.interfaces
{
    public interface IPuestoService
    {
        Task<IEnumerable<Puesto>> Leer();
        Task<Puesto> LeerUno(int id);
    }
}
