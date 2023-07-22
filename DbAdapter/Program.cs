using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

//string connectionString = "Server=DESKTOP-TO8EGSF;Database=P01_dump;Trusted_Connection=True;Encrypt=False;";

string connectionString = ConfigurationManager.ConnectionStrings["Express"].ConnectionString;

using SqlConnection conn = new SqlConnection(connectionString);
try
{
    string selectQuery = "SELECT * FROM users";

    SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn);

    DataSet ds = new DataSet();

    da.Fill(ds);

    foreach (DataTable table in ds.Tables)
    {
        Console.WriteLine($"Table: {table.TableName}");

        // Цикл для вывода заголовков столбцов
        foreach (DataColumn column in table.Columns)
        {
            Console.Write($"{column.ColumnName}\t");
        }
        Console.WriteLine();

        // Цикл для вывода данных
        foreach (DataRow row in table.Rows)
        {
            foreach (var item in row.ItemArray)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR: {ex.Message}");
}
finally 
{
    if(conn.State == ConnectionState.Open)
        conn.Close();
}

