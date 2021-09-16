﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string RUN { get; set; }
        public int EstadoEdicion { get; set; }
        public List<Documento> Documentos { get; set; }
    }
}