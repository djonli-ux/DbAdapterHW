using Microsoft.Data.SqlClient;
using System.Data;


string connectionString = "Server=DESKTOP-TO8EGSF;Database=P01_dump;Trusted_Connection=True;Encrypt=False;"; 
DataSet ds = new DataSet();


using SqlConnection conn = new SqlConnection(connectionString);
try
{
	conn.Open();
    Console.WriteLine("Connection ok...");

}
catch (Exception)
{

	throw;
}

