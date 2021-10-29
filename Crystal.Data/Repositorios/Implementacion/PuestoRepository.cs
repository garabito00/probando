using Crystal.Data.Contexto;
using Crystal.Data.Repositorios.Interfaces;
using Crystal.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Data.Repositorios.Implementacion
{
    public class PuestoRepository : IPuestoRepository
    {
        private readonly CrystalContext _context;

        public PuestoRepository(CrystalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Puesto>> Read()
        {
            return await _context.Puestos.Include(x=> x.Departamento).ToListAsync();
        }

        public async Task<Puesto> ReadOne(int id)
        {
            return await _context.Puestos.Include(x => x.Departamento).FirstAsync(x => x.ID == id);
        }
    }
}
