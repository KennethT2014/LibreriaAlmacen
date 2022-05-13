using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaAlmacen
{
    public class Datos
    {
        private string connectionString;

        protected SqlConnection GetConnection()
        {
            connectionString = @"Server=KENNETH;Initial Catalog = Libreria; Integrated Security = True";
            return new SqlConnection(connectionString);
        }

        public int ExecuteNonQuery(string transactSql, List<SqlParameter> parameters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transactSql;
                    command.CommandType = CommandType.Text;
                    foreach (SqlParameter item in parameters)
                    {
                        command.Parameters.Add(item);
                    }
                    int result = command.ExecuteNonQuery();
                    parameters.Clear();
                    return result;
                }
            }
        }

        public DataTable ExecuteReader(string transactSql, List<SqlParameter> parameters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transactSql;
                    command.CommandType = CommandType.Text;

                    if (parameters != null)
                    {
                        foreach (SqlParameter item in parameters)
                        {
                            command.Parameters.Add(item);
                        }
                    }

                    SqlDataReader reader = command.ExecuteReader();
                    using (var table = new DataTable())
                    {
                        if (parameters != null)
                        {
                            parameters.Clear();
                        }

                        table.Load(reader);
                        reader.Dispose();
                        return table;
                    }
                }
            }
        }
    }
}
