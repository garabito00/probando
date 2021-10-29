using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crystal.Domain.ViewModels
{
    public class EmpleadoViewModel
    {
        //Propiedades
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int PuestoId { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
    }
}
