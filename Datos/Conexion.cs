using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        public SqlConnection getConexion()
        {

            try
            {

                string cadena = @"Data Source=165.98.12.158;Initial Catalog=NeoTechPatrones;User ID=neotech;Password=74zYE0vhDs";
                //DESKTOP-II81846;Initial Catalog=Mediador;Persist Security Info=True;User ID=sa;Password=Usuario123.

                SqlConnection cnn = new SqlConnection(cadena);
                cnn.Open();
                return cnn;

            }
            catch (Exception)
            {
                throw;
                return null;

            }
        }
    }
}
