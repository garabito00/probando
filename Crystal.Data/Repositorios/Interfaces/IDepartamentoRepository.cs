using Crystal.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Data.Repositorios.Interfaces
{
    public interface IDepartamentoRepository
    {
        Task Create(Departamento model);
        Task<Departamento> ReadOne(int id);
        Task<IEnumerable<Departamento>> Read();
        Task Update(Departamento model);
        Task Delete(Departamento model);
    }
}
