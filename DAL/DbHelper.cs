using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Product_Inventory.DAL
{
  public class DbHelper
   {
    private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ProductInventoryConnection"].ConnectionString;


       
            public static SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }


            // Execute INSERT / UPDATE / DELETE Stored Procedure
            public static int ExecuteNonQuery(string storedProcedure,params SqlParameter[] parameters)
            {
                using (SqlConnection connection = GetConnection())
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();

                    return command.ExecuteNonQuery();
                }
            }


            // Execute SELECT Stored Procedure
            public static DataTable ExecuteDataTable(string storedProcedure,params SqlParameter[] parameters)
            {
                DataTable dataTable = new DataTable();

                using (SqlConnection connection = GetConnection())
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                return dataTable;
            }


            // Execute Stored Procedure and return one value
            public static object ExecuteScalar( string storedProcedure,params SqlParameter[] parameters)
            {
                using (SqlConnection connection = GetConnection())
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();

                    return command.ExecuteScalar();
                }
            }
  }
}

