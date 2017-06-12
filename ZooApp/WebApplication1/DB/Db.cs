using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiZoo
{
    public static class Db
    {
        private static SqlConnection conexion = null;

        public static void Conectar()
        {
            try
            {
                // PREPARO LA CADENA DE CONEXIÓN A LA BD
                string cadenaConexion = @"Server=.\sqlexpress;
                                          Database=zoo_pm;
                                          User Id=PMGB;
                                          Password=pinturita23;";

                // CREO LA CONEXIÓN
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                // TRATO DE ABRIR LA CONEXION
                conexion.Open();

                //// PREGUNTO POR EL ESTADO DE LA CONEXIÓN
                //if (conexion.State == ConnectionState.Open)
                //{
                //    Console.WriteLine("Conexión abierta con éxito");
                //    // CIERRO LA CONEXIÓN
                //    conexion.Close();
                //}
            }
            catch (Exception)
            {
                if (conexion != null)
                {
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                    conexion.Dispose();
                    conexion = null;
                }
            }
            finally
            {
                // DESTRUYO LA CONEXIÓN
                //if (conexion != null)
                //{
                //    if (conexion.State != ConnectionState.Closed)
                //    {
                //        conexion.Close();
                //        Console.WriteLine("Conexión cerrada con éxito");
                //    }
                //    conexion.Dispose();
                //    conexion = null;
                //}
            }
        }

        public static bool EstaLaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }

        public static void Desconectar()
        {
            if (conexion != null)
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }

        public static List<Especies> DameLosUsuarios()
        {
            //Usuario[]     usuarios = null;
            List<Especies> usuarios = null;
            // PREPARO LA CONSULTA SQL PARA OBTENER LOS USUARIOS
            string consultaSQL = "SELECT * FROM Especies;";
            // PREPARO UN COMANDO PARA EJECUTAR A LA BASE DE DATOS
            SqlCommand comando = new SqlCommand(consultaSQL, conexion);
            // RECOJO LOS DATOS
            SqlDataReader reader = comando.ExecuteReader();
            usuarios = new List<Especies>();

            while (reader.Read())
            {
                usuarios.Add(new Usuario()
                {
                    idEspecie = int.Parse(reader["idEspecie"].ToString()),
                    idClasificacion = int.Parse(reader["idClasificacion"].ToString(),
                    idTipodeAnimal = int.Parse(reader["idTipodeAnimal"].ToString(),
                    nombre = reader["nombre"].ToString(),
                    nPatas = int.Parse(reader["nPatas"].ToString(),
                                   esMascota bit
                    
                    nombre = reader["nombre"].ToString(),
                    firstName = reader["firstName"].ToString(),
                    lastName = reader["lastName"].ToString(),
                    photoUrl = reader["photoUrl"].ToString(),
                    searchPreferences = reader["searchPreferences"].ToString(),
                    status = bool.Parse(reader["status"].ToString()),
                    deleted = (bool)reader["deleted"],
                    isAdmin = Convert.ToBoolean(reader["isAdmin"])
                });
            }

            // DEVUELVO LOS DATOS
            return usuarios;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}