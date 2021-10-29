using Crystal.Domain.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Domain.Entidades
{
    public class Empleado : ClaseComun
    {
        //Propiedades
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Correo { get; set; }

        //Relacion a entidad Puesto one-to-many
        public int PuestoId { get; set; }
        public Puesto Puesto { get; set; }

        //Relacion a entidad Direccion one-to-one
        public Direccion Direccion { get; set; }

    }
}
