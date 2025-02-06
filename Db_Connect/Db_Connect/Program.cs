using System;
using System.Data.SqlClient;
namespace Db_Connect
{
    public class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            string connectionString = "Data Source=.;Initial Catalog=DBStudent;Integrated Security=True";
            string query = "SELECT * FROM dbo.Table1";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Id"] + " " + reader["Name"]);
                }
                connection.Close();
            }
        }
    }
}