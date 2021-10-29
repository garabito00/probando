using Crystal.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Data.Repositorios.Interfaces
{
    public interface IPuestoRepository
    {
        Task<IEnumerable<Puesto>> Read();
        Task<Puesto> ReadOne(int id);
    }
}
