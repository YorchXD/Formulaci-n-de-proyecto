using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class Resolucion
    {
        public int IdProceso {get; set;}
        public int NumeroResolucion { get; set; }
        public int AnioResolucion { get; set; }
        public string CopiaDocumento { get; set; }
    }
}
