using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class Organizacion
    {
        public int Id;
        public string Tipo { get; set; }
        public List<Responsable> Responsables { get; set; }
    
        public Federacion federacion {get; set;};
        public CAA caa {get; set;}
    }
}
