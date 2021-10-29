using Crystal.Data.Contexto;
using Crystal.Data.Repositorios.Interfaces;
using Crystal.Domain.Comun;
using Crystal.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Data.Repositorios.Implementacion
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ClaseComun
    {
        private readonly CrystalContext _context;

        public GenericRepository(CrystalContext context)
        {
            _context = context;
        }
        public async Task Create(T model)
        {
            _context.Set<T>().Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T model)
        {
            _context.Set<T>().Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Read()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> ReadOne(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Update(T model)
        {
            _context.ChangeTracker.Clear();
            _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
