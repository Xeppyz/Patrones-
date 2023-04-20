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
    public class Operacion
    {
        public bool InsertDocente(string nombre, string direccion, string correo, string telefono)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-II81846;Initial Catalog=Mediador;Persist Security Info=True;User ID=sa;Password=Usuario123."))
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO Docente (nombre, direccion, correo, telefono) VALUES (@nombre, @direccion, @correo, @telefono)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    int n = cmd.ExecuteNonQuery();
                    return n > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

    }

}

