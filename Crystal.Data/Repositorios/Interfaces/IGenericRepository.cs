using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Data.Repositorios.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task Create(T model);
        Task<T> ReadOne(int id);
        Task<IEnumerable<T>> Read();
        Task Update(T model);
        Task Delete(T model);
    }
}
