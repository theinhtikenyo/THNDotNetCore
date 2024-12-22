using System.Data;
using System.Data.SqlClient;

string connectionString = "Server=.;Database=master;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;";
// crtl + . to import the namespace
SqlConnection connection = new SqlConnection(connectionString);
Console.WriteLine("Connection Opening");
connection.Open();

Console.WriteLine("Connection Opened");
string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContents]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog]";
SqlCommand command = new SqlCommand(query, connection);

//Using FILL (low performance)
//SqlDataAdapter adapter = new SqlDataAdapter(command);
//DataTable dataTable = new DataTable();
//adapter.Fill(dataTable);

//foreach (DataRow row in dataTable.Rows)
//{
//    Console.WriteLine($"BlogId: {row["BlogId"]}, BlogTitle: {row["BlogTitle"]}, BlogAuthor: {row["BlogAuthor"]}, BlogContents: {row["BlogContents"]}, DeleteFlag: {row["DeleteFlag"]}");
//}
SqlDataReader reader = command.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine($"BlogId: {reader["BlogId"]}, BlogTitle: {reader["BlogTitle"]}, BlogAuthor: {reader["BlogAuthor"]}, BlogContents: {reader["BlogContents"]}, DeleteFlag: {reader["DeleteFlag"]}");
}

Console.WriteLine("Connection Closed");
connection.Close();

