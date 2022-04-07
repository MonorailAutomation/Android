using System;
using System.Data.SqlClient;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.Database
{
    public static class Track
    {
        public static string GetTrackId(string email, string trackName)
        {
            Guid? trackId = null;
            try
            {
                var sqlConnection = new SqlConnection(DatabaseConfig.Builder(MonorailTestEnvironment).ConnectionString);
                sqlConnection.Open();

                var query =
                    "select Spots.Id, Spots.Name from Spots join Users on Users.Id = Spots.UserId where Users.Email=\'" +
                    email + "\' and Spots.Name=\'" + trackName + "\' ";

                var command = new SqlCommand(query, sqlConnection);
                var reader = command.ExecuteReader();

                while (reader.Read()) trackId = reader.GetGuid(0);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return trackId.ToString();
        }
    }
}