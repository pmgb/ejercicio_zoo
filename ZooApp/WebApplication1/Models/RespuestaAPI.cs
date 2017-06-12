using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiZoo
{
    public class RespuestaAPI
    {
        public int totalElementos { get; set; }

        public string error { get; set; }

        public List<Clasificaciones> data { get; set; }

        public List<Especies> dataEspecies { get; set; }

        public List<TiposAnimal> dataTiposAnimal { get; set; }
    }
}