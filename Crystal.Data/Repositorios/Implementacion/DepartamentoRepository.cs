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
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly CrystalContext _context;

        public DepartamentoRepository(CrystalContext context)
        {
            _context = context;
        }

        public async Task Create(Departamento model)
        {
            _context.Departamentos.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Departamento model)
        {
            _context.ChangeTracker.Clear();
            _context.Departamentos.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Departamento>> Read()
        {
            return await _context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> ReadOne(int id)
        {
            return await _context.Departamentos.FindAsync(id);
        }

        public async Task Update(Departamento model)
        {
            _context.ChangeTracker.Clear();
            _context.Departamentos.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
