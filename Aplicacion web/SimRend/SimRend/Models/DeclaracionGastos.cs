using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class DeclaracionGastos
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaLimite { get; set; }
        public int TotalDocumentacion { get; set; }
        public int TotalRendido { get; set; }
    }
}
