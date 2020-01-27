using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace SimRend.Models
{
    public class Solicitud
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaActual { get; set; }
        public int Monto { get; set; }
        public string NombreEvento { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicioEvento { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaTerminoEvento { get; set; }
        public string LugarEvento { get; set; }
        public string RutResponsable { get; set; }

        public string NombreResponsable { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaFinPdf { get; set; }

        public string FechaPdf {get; set;}

        public int MontoPorPersona { get; set; }
       
       /*Esta variable se utiliza para colocar la fecha de inicio y termino del evento en un solo string*/
        public string FechaEvento { get; set; }
        
        public string TipoActividad {get; set;}
    }
}
