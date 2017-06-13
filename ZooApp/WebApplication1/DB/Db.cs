using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiZoo
{
    //Hoy 13-6-17 19:00
    public static class Db
    {
        private static SqlConnection conexion = null;
        private static string esMascota;

        public static void Conectar()
        {
            try
            {
                // PREPARO LA CADENA DE CONEXIÓN A LA BD
                string cadenaConexion = @"Server=.\sqlexpress;
                                          Database=Zoo_pm;
                                          User Id=PMGB;
                                          Password=pinturita23;";

                // CREO LA CONEXIÓN
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                // TRATO DE ABRIR LA CONEXION
                conexion.Open();

                // PREGUNTO POR EL ESTADO DE LA CONEXIÓN
                if (conexion.State == ConnectionState.Open)
                {
                    Console.WriteLine("Conexión abierta con éxito");
                // CIERRO LA CONEXIÓN
                    conexion.Close();
                }
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
                ////DESTRUYO LA CONEXIÓN
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

              
        public static List<Clasificaciones> GetClasificaciones()
        {
            List<Clasificaciones> resultado = new List<Clasificaciones>();
            //Hecho
            // PREPARO EL PROCEDIMIENTO A EJECUTAR
            string procedimiento = "dbo.GetClasificaciones";
            // PREPARO EL COMANDO PARA LA BD
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            // INDICO QUE LO QUE VOY A EJECUTAR ES UN PA
            comando.CommandType = CommandType.StoredProcedure;
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // PROCESO EL RESULTADO Y LO MENTO EN LA VARIABLE
            while (reader.Read())
            {
                Clasificaciones clasificacion = new Clasificaciones();

                clasificacion.IdClasificacion = (int)reader["IdClasificacion"];
                clasificacion.denominacion = reader["denominacion"].ToString();
                // añadiro a la lista que voy
                // a devolver
                resultado.Add(clasificacion);
            }

            return resultado;
        }

        public static List<Especies> GetEspecies()
    {
        List<Especies> resultado = new List<Especies>();

        // PREPARO EL PROCEDIMIENTO A EJECUTAR
        string procedimiento = "dbo.GetEspecies";
        // PREPARO EL COMANDO PARA LA BD
        SqlCommand comando = new SqlCommand(procedimiento, conexion);
        // INDICO QUE LO QUE VOY A EJECUTAR ES UN PA
        comando.CommandType = CommandType.StoredProcedure;
        // EJECUTO EL COMANDO
        SqlDataReader reader = comando.ExecuteReader();
        // PROCESO EL RESULTADO Y LO MENTO EN LA VARIABLE
        while (reader.Read())
            {
            Especies especie = new Especies();

                //especies.IdClasificacion = (int)reader["IdClasificacion"];
                //clasificacion.denominacion = reader["denominacion"].ToString();

                especie.idEspecie = long.Parse(reader["idEspecie"].ToString(),
                especie.idClasificacion = int.Parse(reader["idClasificacion"].ToString(),
                especie.idTipodeAnimal = int.Parse(reader["IdTipodeAnimal"].ToString(),
                especie.nombre = reader["nombre"].ToString(),
                especie.nPatas = int.Parse(reader["nPatas"].ToString(),
                especie.esMascota = int.Parse(reader["esMascota"].ToString();
                // añadiro a la lista que voy
                // a devolver
                resultado.Add(especie);
             }

        return resultado;
    }

        public static List<TiposAnimal> GetTiposAnimal()
        {
            List<TiposAnimal> resultados = new List<TiposAnimal>();
            string procedimiento = "dbo.GetTiposAnimales";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                TiposAnimal tipo = new TiposAnimal();
                tipo.IdTipoAnimal = (int)reader["IdTiposAnimal"];
                tipo.denominacion = reader["denominacion"].ToString();
                resultados.Add(tipo);
            }


            return resultados;
        }

    }

}
       