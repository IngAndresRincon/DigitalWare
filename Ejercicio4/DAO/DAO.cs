﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO
    {
        public SqlConnection conexion;
        
        public DAO()
        {
            string cadena = ConfigurationManager.AppSettings["ConexionSQL"];
            conexion = new SqlConnection(cadena);            
        }

    

    }
}
