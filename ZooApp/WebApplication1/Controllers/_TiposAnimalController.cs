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
        public RespuestaAPI Get()
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Especies> data = new List<Especies>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.DameListaCochesConProcedimientoAlmacenado();
                    resultado.error = "";
                }
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Error";
            }
            resultado.totalElementos = data.Count;
            resultado.data = data;
            return resultado;

        }

        // GET: api/Coches/5
        public RespuestaAPI Get(long id)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Especies> data = new List<Especies>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.DameListaCochesConProcedimientoAlmacenadoPorId(id);
                    resultado.error = "";
                }
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Error";
            }
            resultado.totalElementos = data.Count;
            resultado.data = data;
            return resultado;

        }
        // POST: api/Coches
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Coches/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Coches/5
        public void Delete(int id)
        {
        }
    }
}

