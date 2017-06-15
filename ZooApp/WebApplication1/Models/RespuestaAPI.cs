using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiZoo
{
    public class RespuestaAPI
    {
        internal List<Clasificaciones> dataClasificacion;

        public int totalElementos { get; set; }

        public string error { get; set; }

        public List<Clasificaciones> dataClasificaciones { get; set; }

        public List<Especies> dataEspecies { get; set; }

        public List<TiposAnimal> dataTiposAnimal { get; set; }
    }
}