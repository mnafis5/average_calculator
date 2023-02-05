using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Math_Calculator_App
{
    class Db_connection : Program
    {
        private static string ConnectionString()
        {
            string connectionString = "Server=127.0.0.1;Database=Math_Calculator_App;username=postgres;Password=root";
            return connectionString;
        }
        public NpgsqlConnection connection = new NpgsqlConnection(ConnectionString());
        public Db_connection()
        {
            try
            {
                connection.Open();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        public void Db_Insert(string input)
        {
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO Calculator (histories_) VALUES (@histories_)";
                command.Parameters.AddWithValue("histories_", input);
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Number of rows inserted: " + rowsAffected);
            }
        }

        public void Db_retrieve()
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM Calculator";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        Console.Write($"{reader["id"]} |{reader["histories_"]}\t|{reader["created_at"]}\n");
                    }
                }
            }
        }

        public void Db_Delete()
        {
            using (NpgsqlCommand comd = new NpgsqlCommand())
            {
                comd.Connection = connection;
                comd.CommandText = "DELETE FROM Calculator";
                int rowsAffected = comd.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " history deleted");
            }
        }

        public int Db_Count()
        {
            using (NpgsqlCommand cd = new NpgsqlCommand("SELECT COUNT(*) FROM Calculator", connection))
            {
                int rowCount = (int)cd.ExecuteScalar();
                return rowCount;
            }
        }
    }
}
