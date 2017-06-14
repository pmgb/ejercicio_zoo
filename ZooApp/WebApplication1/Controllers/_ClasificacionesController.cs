using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiZoo.Controllers
{
    public class _ClasificacionesController : ApiController
       {
        // GET: api/Clasificaciones
        public RespuestaAPI Get()
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Clasificaciones> listaClasificacion = new List<Clasificaciones>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    listaClasificacion = Db.GetClasificaciones();
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = listaClasificacion.Count;
            resultado.dataClasificacion = listaClasificacion;
            return resultado;
        }
        //Bien arriba

        // GET: api/Clasificaciones/5
        public RespuestaAPI Get(long id)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Clasificaciones> listaClasificaciones = new List<Clasificaciones>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaClasificaciones = Db.GetClasificacionesPorId(id);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = listaClasificaciones.Count;
            resultado.dataClasificacion = listaClasificaciones;
            return resultado;
        }

        // POST: api/Clasificaciones
        [HttpPost]
        public IHttpActionResult Post([FromBody] Clasificaciones Clasificaciones)
        {
            RespuestaAPI respuesta = new RespuestaAPI();
            respuesta.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarClasificaciones(clasificaciones);
                }

                respuesta.totalElementos = filasAfectadas;

                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Error al agregar la marca";
            }

            return Ok(respuesta);
        }

        // PUT: api/Clasificaciones/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Clasificaciones Clasificaciones)
        {
            return Ok(Clasificaciones);
        }

        // DELETE: api/Clasificaciones/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            RespuestaAPI respuesta = new RespuestaAPI();
            respuesta.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.EliminarClasificaciones(id);
                }
                respuesta.totalElementos = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Error al eliminar la marca";
            }
            return Ok(respuesta);
        }
    }
}