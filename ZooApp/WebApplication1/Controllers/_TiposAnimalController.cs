using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiZoo.Controllers
{
    public class _TiposAnimalController : ApiController
    {
        //Get: api/TiposAnimal
        public RespuestaAPI Get()
        {
            RespuestaAPI respuesta = new RespuestaAPI();
            List<TiposAnimal> dataTiposAnimal = new List<TiposAnimal>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    dataTiposAnimal = Db.GetTiposAnimal();
                    //dataTiposAnimal = Db.DameListaEspeciesConProcedimientoAlmacenado();
                    respuesta.error = "";
                }
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuesta.error = "Error";
            }
            respuesta.totalElementos = dataTiposAnimal.Count;
            respuesta.dataTiposAnimal = dataTiposAnimal;
            return respuesta;

        }
        // GET: api/TiposAnimal
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TiposAnimal
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TiposAnimal/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TiposAnimal/5
        public void Delete(int id)
        {
        }
    }
}


//        // GET: api/Coches/5
//        public RespuestaAPI Get(long id)
//        {
//            RespuestaAPI resultado = new RespuestaAPI();
//            List<TiposAnimal> data = new List<TiposAnimal>();
//            try
//            {
//                Db.Conectar();
//                if (Db.EstaLaConexionAbierta())
//                {
//                    data = Db.DameListaEspeciesConProcedimientoAlmacenadoPorId(id);
//                    resultado.error = "";
//                }
//                Db.Desconectar();
//            }
//            catch (Exception ex)
//            {
//                resultado.error = "Error";
//            }
//            resultado.totalElementos = data.Count;
//            resultado.dataTiposAnimal = data;
//            return resultado;

//        }
//        // POST: api/Coches
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT: api/Coches/5
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE: api/Coches/5
//        public void Delete(int id)
//        {
//        }
//    }
//}

