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
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _repo;
        public DepartamentoService(IDepartamentoRepository repo)
        {
            _repo = repo;
        }
        public async Task Actualizar(Departamento depa)
        {
            var result = await _repo.ReadOne(depa.ID);
            try
            {
                await _repo.Update(depa);
            }
            catch (Exception e)
            {
                throw new Exception($"No se Actualizo el registro en la base de datos. Mensaje: {e.Message}");
            }
        }

        public async Task Borrar(Departamento depa)
        {
            if (!(await _repo.ReadOne(depa.ID) == null))
            {
                try
                {
                    await _repo.Delete(depa);
                }
                catch (Exception e)
                {
                    throw new Exception($"No se Borro el registro en la base de datos. Mensaje: {e.Message}");
                }
            }
        }

        public async Task Crear(Departamento depa)
        {
            try
            {
                await _repo.Create(depa);

            } catch(Exception e)
            {
                throw new Exception($"No se pudo crear el registro en la base de datos. Mensaje: {e.Message}");
            }
        }

        public async Task<IEnumerable<Departamento>> Leer()
        {
            try
            {
                var result = await _repo.Read();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"No se encontraron registros en la base de datos. Mensaje: {e.Message}");
            }
        }

        public async Task<Departamento> LeerUno(int id)
        {
            try
            {
                var result = await _repo.ReadOne(id);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"No se encontraro registro en la base de datos. Mensaje: {e.Message}");
            }
        }
    }
}
