using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;


namespace Datos
{
    public class OpInsert
    {

        public bool InsertPersona(string nombre, string edad, string materia)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=165.98.12.158;Initial Catalog=NeoTechPatrones;User ID=neotech;Password=74zYE0vhDs"))
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO Persona (nombre, edad, materia) VALUES (@nombre, @edad, @materia)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@edad", edad);
                    cmd.Parameters.AddWithValue("@materia", materia);
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
