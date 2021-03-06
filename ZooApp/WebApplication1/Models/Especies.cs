﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ApiZoo
{
    public class Especies
    {
        internal string denominacion;

        public long idEspecie { get; set; }
        public int idClasificacion { get; set; }
        public int idTipodeAnimal { get; set; }
        public string nombre { get; set; }
        public int nPatas { get; set; }
        public int esMascota { get; set; }
        public int IdClasificacion { get; internal set; }
        public int IdTipoAnimal { get; internal set; }

        public static implicit operator Especies(TiposAnimal v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Especies(Clasificaciones v)
        {
            throw new NotImplementedException();
        }
    }
}
