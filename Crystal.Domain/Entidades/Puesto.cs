using Crystal.Domain.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Domain.Entidades
{
    public class Puesto : ClaseComun
    {
        //Propiedades
        public int ID { get; set; }
        public string Rol { get; set; }
        public double Sueldo { get; set; }

        //Relacion con la entidad de Empleados
        public IEnumerable<Empleado> Empleados { get; set; }

        //Relacion con la entidad de Departamento
        public int DepartamentoID { get; set; }
        public Departamento Departamento { get; set; }
    }
}
