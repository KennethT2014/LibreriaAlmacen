using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaAlmacen
{
    public class ContactoBd
    {
        string connectionString = @"Server=KENNETH;Initial Catalog = Libreria; Integrated Security = True";

        public List<Libreria> Get()
        {
            List<Libreria> libreria = new List<Libreria>();

            string queryString = "SELECT Titulo, ISBN";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Libreria alibreria = new Libreria();
                        alibreria.Titulo = reader.GetInt32(0);
                        alibreria.ISBN = reader.GetString(1);
                        libreria.Add(alibreria);
                    }
                    reader.Close();
                }catch (Exception ex)
                {
                    throw new Exception("Hay un error en la BD"+ ex.Message);
                }
            }
            return libreria;
        }

        public Libreria Get(int Titulo)
        {
            string queryString = "SELECT Titulo, ISBN";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                Command.Parameters.AddWithValue("@Titulo", Titulo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Libreria alibreria = new Libreria();
                    alibreria
                }
            }
        }
    }
}
