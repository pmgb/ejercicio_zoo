using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiZoo.Controllers
{
    public class _EspeciesController : ApiController
       {
        // GET: api/Especies
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //public IEnumerable<Coche> Get()
        public RespuestaAPI Get()
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Especies> dataEspecies = new List<Especies>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    dataEspecies = Db.GetEspecies();
                    //data = Db.DameListaEspeciesConProcedimientoAlmacenado();
                    resultado.error = "";
                }
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Error";
            }
            resultado.totalElementos = dataEspecies.Count;
            resultado.dataEspecies = dataEspecies;
            return resultado;

            //resultado.totalElementos = data.Count;
            //resultado.data = data;
            //return resultado;

        }


        ////Todo lo de abajo está mal
        //// GET: api/Coches/5
        //public RespuestaAPI Get(long id)
        //{
        //    RespuestaAPI resultado = new RespuestaAPI();
        //    List<Especies> dataEspecies = new List<Especies>();
        //    try
        //    {
        //        Db.Conectar();
        //        if (Db.EstaLaConexionAbierta())
        //        {
        //            dataEspecies = Db.DameListaEspeciesConProcedimientoAlmacenadoPorId(id);
        //            //dataEspecies = Db.DameListaEspeciesConProcedimientoAlmacenadoPorId(id);
        //            resultado.error = "";
        //        }
        //        Db.Desconectar();
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.error = "Error";
        //    }
        //    resultado.totalElementos = dataEspecies.Count;
        //    resultado.dataEspecies = dataEspecies;
        //    return resultado;

        //}

        // GET: api/Especies/5
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

        // POST: api/Especies
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Especies/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Espcies/5
        public void Delete(int id)
        {
        }
    }
}
