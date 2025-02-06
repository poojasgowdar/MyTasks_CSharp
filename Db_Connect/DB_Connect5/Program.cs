using System.Data.SqlClient;
public class test
{
    public static void Main(string[] args)
    {
        string connectionString = "Data Source=localhost;Initial Catalog=DBStudent;Integrated Security=True";
        string query = "SELECT * FROM dbo.Employee";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
           SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["empId"] + " " + reader["empName"] + " " + reader["empSal"] + " " + reader["phone_no"]);
            }
            connection.Close();
        }

    }
}