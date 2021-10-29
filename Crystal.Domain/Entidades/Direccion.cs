using Crystal.Domain.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Domain.Entidades
{
    public class Direccion : ClaseComun
    {
        //Propiedades
        public int ID { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }

        //Relacion con entidad Empleado
        public int EmpleadoID { get; set; }
        public Empleado Empleado { get; set; }
    }
}
