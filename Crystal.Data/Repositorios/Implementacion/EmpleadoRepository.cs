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
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly CrystalContext _context;
        public EmpleadoRepository(CrystalContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Empleado emp)
        {
            _context.Empleados.Add(emp);
            await _context.SaveChangesAsync();
            return emp.ID;
        }
        public async Task CreateDir(Direccion dir)
        {           
            _context.Direcciones.Add(dir);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Empleado>> Read()
        {
            return await _context.Empleados.Include(x => x.Puesto).Include(x => x.Direccion).ToListAsync();
        }

        public async Task<Empleado> ReadOne(int id)
        {
            return await _context.Empleados.Include(x => x.Puesto).Include(x => x.Direccion).FirstAsync(x => x.ID == id);
        }
    }
}
