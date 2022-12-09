using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ejercicio5
{
    public class Conexion
    {

        public SqlConnection conexion;

        public Conexion()
        {
            string cadena = ConfigurationManager.AppSettings["ConexionSQL"];
            conexion = new SqlConnection(cadena);
        }

    }

}