using System.Collections.Generic;

namespace SimRend.Models
{
    public class Rendicion
    {
        public int Id {get; set; }
        public Organizacion Organizacion{get; set; }
        public Responsable Responsable {get; set; }
        public Resolucion Resolucion {get; set; }
        public int TotalRendido {get; set; }
        public int DiasDisponibles {get; set; }
        public List<Documento> Documentos { get; set; }
    
        
    }
}