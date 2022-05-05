using System;
using System.Data.SqlClient;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.Database
{
    public static class RetrieveUser
    {
        public static string GetUserId(string email)
        {
            Guid? userId = null;
            try
            {
                var sqlConnection = new SqlConnection(DatabaseConfig.Builder(MonorailTestEnvironment).ConnectionString);
                sqlConnection.Open();

                var query = "select top 1 id from Users where Users.email=\'" + email + "\'";

                var command = new SqlCommand(query, sqlConnection);
                var reader = command.ExecuteReader();

                while (reader.Read()) userId = reader.GetGuid(0);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return userId.ToString();
        }
    }
}