using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class Proceso
    {
        public int Id { get; set; }
        public Responsable Responsable { get; set; }
        public Direccion Direccion { get; set; }
        public Organizacion Organizacion { get; set; }
        public int Estado { get; set; }
        public Solicitud Solicitud { get; set; }
        public Resolucion Resolucion { get; set; }
        public DeclaracionGastos DeclaracionGastos { get; set; }
    }
}
