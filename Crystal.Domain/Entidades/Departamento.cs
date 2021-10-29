using Crystal.Domain.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Domain.Entidades
{
    public class Departamento : ClaseComun
    {
        //propiedades
        public int ID { get; set; }
        public string Nombre { get; set; }

        //Relacion con la entidad Puesto
        public IEnumerable<Puesto> Puestos { get; set; }
    }
}
