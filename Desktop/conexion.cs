﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    class conexion
    {
        string cadena = @"Data Source=DESKTOP-015KCQB\SQLEXPRESS;Initial Catalog=Medilife;Integrated Security=True";
                  
        public SqlConnection conectarbd = new SqlConnection();
        public conexion()
        {
            conectarbd.ConnectionString = cadena;
        }

        public void abrir()
        {
            try
            {
                conectarbd.Open();
                //MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al abrir" + ex.Message);
            }
        }
        public void cerrar()
        {
            conectarbd.Close();
        }
    }
}
