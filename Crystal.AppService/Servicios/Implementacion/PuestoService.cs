using Crystal.AppService.Servicios.interfaces;
using Crystal.Data.Repositorios.Interfaces;
using Crystal.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.AppService.Servicios.Implementacion
{
    public class PuestoService : IPuestoService
    {
        private readonly IPuestoRepository _repo;
        public PuestoService(IPuestoRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Puesto>> Leer()
        {
            return await _repo.Read();
        }

        public async Task<Puesto> LeerUno(int id)
        {
            return await _repo.ReadOne(id);
        }
    }
}
