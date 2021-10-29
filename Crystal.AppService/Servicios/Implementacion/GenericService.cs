using Crystal.AppService.Servicios.interfaces;
using Crystal.Data.Repositorios.Interfaces;
using Crystal.Domain.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.AppService.Servicios.Implementacion
{
    public class GenericService<T> : IGenericService<T> where T : ClaseComun
    {
        private readonly IGenericRepository<T> _repo;

        public GenericService(IGenericRepository<T> repo)
        {
            _repo = repo;
        }
        public async Task Actualizar(int id, T model)
        {
            if(!(await _repo.ReadOne(id) == null))
            {
                try
                {
                    await _repo.Update(model);
                }
                catch (Exception e)
                {
                    throw new Exception($"No se actulizar el registro de la base de datos. Mensaje: {e.Message}");
                }
            }

        }

        public async Task Borrar(int id)
        {
            var result = await _repo.ReadOne(id);
            try
            {
                await _repo.Delete(result);
            }
            catch (Exception e)
            {
                throw new Exception($"No se pudo Borrar el registro en la base de datos. Mensaje: {e.Message}");
            }
        }

        public async Task Crear(T model)
        {
            try
            {

                await _repo.Create(model);

            } catch (Exception e)
            {
                throw new Exception($"No se pudo Crear el registro en la base de datos. Mensaje: {e.Message}");
            }
        }

        public async Task<IEnumerable<T>> Leer()
        {
            try
            {

                var result = await _repo.Read();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"No se pudo traer los registros de la base de datos. Mensaje: {e.Message}");
            }

        }

        public async Task<T> LeerUno(int id)
        {
            try
            {

                var result = await _repo.ReadOne(id);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"No se pudo traer el registro de la base de datos. Mensaje: {e.Message}");
            }
        }
    }
}
