using Crystal.AppService.Servicios.interfaces;
using Crystal.Data.Repositorios.Interfaces;
using Crystal.Domain.Entidades;
using Crystal.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.AppService.Servicios.Implementacion
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repo;
        public EmpleadoService(IEmpleadoRepository repo)
        {
            _repo = repo;
        }

        public async Task Crear(EmpleadoViewModel emp)
        {
            var empleado = new Empleado()
            {
                Nombre = emp.Nombre,
                Apellido = emp.Apellido,
                PuestoId = emp.PuestoId
            };

            var direccion = new Direccion()
            {
                Calle = emp.Calle,
                Ciudad = emp.Ciudad,
                Telefono = emp.Telefono,
                Pais = emp.Pais
            };

            try
            {
                var id = await _repo.Create(empleado);
                direccion.EmpleadoID = id;
                await _repo.CreateDir(direccion);

            } catch (Exception e)
            {
                throw new Exception($"Se produjo un error al registrar el empleado. Mensaje {e.Message}");
            }
            
        }

        public async Task<IEnumerable<Empleado>> Leer()
        {
            return await _repo.Read();
        }

        public async Task<Empleado> LeerUno(int id)
        {
            return await _repo.ReadOne(id);
        }
    }
}
