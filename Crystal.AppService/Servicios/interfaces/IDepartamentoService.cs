using Crystal.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.AppService.Servicios.interfaces
{
    public interface IDepartamentoService
    {
        Task Crear(Departamento depa);
        Task<IEnumerable<Departamento>> Leer();
        Task<Departamento> LeerUno(int id);
        Task Actualizar(Departamento depa);
        Task Borrar(Departamento depa);
    }
}
