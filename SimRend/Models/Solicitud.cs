using System;
using System.ComponentModel.DataAnnotations;

namespace SimRend.Models
{
    public class Solicitud
    {
        public int ID { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaActual{ get; set;}
        public int Monto { get; set; }
        public string NombreEvento { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaEvento { get; set; }
        public string LugarEvento { get; set; }
        public string Responsable { get; set; }
    }
}