﻿using ApiZoo;
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
    //Hoy 14-6-17 16:15
    //Hoy 14-6-17 19:06
    //Hoy 15-6-17 16:17
    //Hoy 15-6-17 18:53
    public static class Db
    {
        private static SqlConnection conexion = null;

        public static object Especie { get; private set; }
        public static object CLasificaciones { get; private set; }

        //private static string esMascota;

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





        public static List<Especies> DameListaEspeciesConProcedimientoAlmacenado()
        { //Yo 14-6-17
            // CREO EL OBJETO EN EL QUE SE DEVOLVERÁN LOS RESULTADOS
            List<Especies> resultados = new List<Especies>();

            // PREPARO LA LLAMADA AL PROCEDIMIENTO ALMACENADO
            string procedimientoAEjecutar = "dbo.GET_ESPECIES_POR_CLASIFICACIONES";
            //string procedimientoAEjecutar = "dbo.GET_COCHE_POR_MARCA";

            //GET_ESPECIES_POR_CLASIFICACIONES

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // RECORRO EL RESULTADO Y LO PASO A LA VARIABLE A DEVOLVER
            while (reader.Read())
            {
                // CREO LA ESPECIE
                Especies Especies = new Especies();
                Especies.idEspecie = (long)reader["idEspecie"];
                Especies.idClasificacion = (int)reader["idClasificacion"];
                Especies.idTipodeAnimal = (int)reader["idTipodeAnimal"];
                Especies.nombre = reader["nombre"].ToString();
                Especies.nPatas = (int)reader["nPatas"];
                Especies.esMascota = (int)reader["esMascota"];
                Especies Clasificacion = new Clasificaciones();
                Clasificacion.IdClasificacion = (int)reader["IdClasificacionClasificaciones"];
                Clasificacion.denominacion = reader["denominacionClasificaciones"].ToString();
                Especies TiposAnimal = new TiposAnimal();
                TiposAnimal.IdTipoAnimal = (int)reader["IdTipoAnimalTiposAnimal"];
                TiposAnimal.denominacion = reader["denominacionTiposAnimal"].ToString();
                resultados.Add(Especies);
            }

            return resultados;
        }




        public static List<Clasificaciones> GetClasificacionPorId(long id)
        {
            List<Clasificaciones> resultado = new List<Clasificaciones>();

            // PREPARO EL PROCEDIMIENTO A EJECUTAR
            string procedimiento = "dbo.Get_Clasificaciones_ID";
            // PREPARO EL COMANDO PARA LA BD
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            // INDICO QUE LO QUE VOY A EJECUTAR ES UN PA
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "id";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // PROCESO EL RESULTADO Y LO MENTO EN LA VARIABLE
            while (reader.Read())
            {
                Clasificaciones Clasificacion = new Clasificaciones();
                Clasificacion.IdClasificacion = (int)reader["IdClasificacion"];
                Clasificacion.denominacion = reader["denominacionClasificaciones"].ToString();
                // añadiro a la lista que voy
                // a devolver
                resultado.Add(Clasificacion);
            }

            return resultado;
        }

        public static int AgregarClasificaciones(Clasificaciones Clasificaciones)
        {
            string procedimiento = "dbo.AgregarClasificacion";
            //OK
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "denominacion";
            parametro.SqlDbType = SqlDbType.NVarChar;
            parametro.SqlValue = Clasificaciones.denominacion;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int EliminarClasificacion(long id)
        {
            string procedimiento = "dbo.ELiminarClasificacion";
            //Nuevo, sin terminar
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "id";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = id;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static List<Especies> DameListaEspeciesConProcedimientoAlmacenadoPorId(long id)
        {
            // CREO EL OBJETO EN EL QUE SE DEVOLVERÁN LOS RESULTADOS
            List<Especies> resultados = new List<Especies>();

            // PREPARO LA LLAMADA AL PROCEDIMIENTO ALMACENADO
            string procedimientoAEjecutar = "dbo.GET_ESPECIES_POR_CLASIFICACIONES";

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO
            SqlCommand comando = new SqlCommand(procedimientoAEjecutar, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "id";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // RECORRO EL RESULTADO Y LO PASO A LA VARIABLE A DEVOLVER
            while (reader.Read())
            {
                Especies Especies = new Especies();
                Especies.idEspecie = (long)reader["idEspecie"];
                Especies.idClasificacion = (int)reader["idClasificacion"];
                Especies.idTipodeAnimal = (int)reader["idTipodeAnimal"];
                Especies.nombre = reader["nombre"].ToString();
                Especies.nPatas = (int)reader["nPatas"];
                Especies.esMascota = (int)reader["esMascota"];
                Especies Clasificaciones = new Clasificaciones();
                Clasificaciones.IdClasificacion = (int)reader["IdClasificacionClasificaciones"];
                Clasificaciones.denominacion = reader["denominacionClasificaciones"].ToString();
                Especies TiposAnimal = new TiposAnimal();
                TiposAnimal.IdTipoAnimal = (int)reader["IdTipoAnimalTiposAnimal"];
                TiposAnimal.denominacion = reader["denominacionTiposAnimal"].ToString();
                resultados.Add(Especies);

                //Coche coche = new Coche();
                //coche.id = (long)reader["id"];
                //coche.matricula = reader["matricula"].ToString();
                //coche.color = reader["color"].ToString();
                //coche.cilindrada = (decimal)reader["cilindrada"];
                //coche.nPlazas = (short)reader["nPlazas"];
                //coche.fechaMatriculacion = (DateTime)reader["fechaMatriculacion"];
                //coche.marca = new Marca();
                //coche.marca.id = (long)reader["idMarca"];
                //coche.marca.denominacion = reader["denominacionMarca"].ToString();
                //coche.tipoCombustible = new TipoCombustible();
                //coche.tipoCombustible.id = (long)reader["idTipoCombustible"];
                //coche.tipoCombustible.denominacion = reader["denominacionTipoCombustible"].ToString();
                // AÑADO EL COCHE A LA LISTA DE RESULTADOS
                resultados.Add(Especies);
                //new
               


            }

            return resultados;
        }



        //    Coche coche = new Coche();
        //    coche.id = (long)reader["id"];
        //    coche.matricula = reader["matricula"].ToString();
        //    coche.color = reader["color"].ToString();
        //    coche.cilindrada = (decimal)reader["cilindrada"];
        //    coche.nPlazas = (short)reader["nPlazas"];
        //    coche.fechaMatriculacion = (DateTime)reader["fechaMatriculacion"];
        //    coche.marca = new Marca();
        //    coche.marca.id = (long)reader["idMarca"];
        //    coche.marca.denominacion = reader["denominacionMarca"].ToString();
        //    coche.tipoCombustible = new TipoCombustible();
        //    coche.tipoCombustible.id = (long)reader["idTipoCombustible"];
        //    coche.tipoCombustible.denominacion = reader["denominacionTipoCombustible"].ToString();
        //    // AÑADO EL COCHE A LA LISTA DE RESULTADOS
        //    resultados.Add(coche);

        //}

        //        return resultados;
        //    }


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

                especie.idEspecie = long.Parse(reader["idEspecie"].ToString());
                especie.idClasificacion = int.Parse(reader["idClasificacion"].ToString());
                especie.idTipodeAnimal = int.Parse(reader["IdTipodeAnimal"].ToString());
                especie.nombre = reader["nombre"].ToString();
                especie.nPatas = int.Parse(reader["nPatas"].ToString());
                especie.esMascota = int.Parse(reader["esMascota"].ToString());
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
       