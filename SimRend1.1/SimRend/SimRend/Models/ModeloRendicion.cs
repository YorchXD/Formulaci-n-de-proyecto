using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class ModeloRendicion
    {
        public SimRend.Models.Solicitud Solicitud { get; set; }
        public SimRend.Models.Resolucion Resolucion { get; set; }
        public SimRend.Models.Rendicion Rendicion { get; set; }
        public IEnumerable<SimRend.Models.Persona> Participantes { get; set; }
        public SimRend.Models.Documento Documento { get; set; }
        public IEnumerable<SimRend.Models.Documento> Documentos { get; set; }
        public IEnumerable<string> ListaTipoDoc = new List<string>() { "Boleta", "Factura"};
        

    }
}