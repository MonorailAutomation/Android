using System;
using System.Data.SqlClient;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.Database
{
    public static class VerificationCode
    {
        public static string GetVerificationCode(string email)
        {
            string verificationCode = null;
            try
            {
                var sqlConnection = new SqlConnection(DatabaseConfig.Builder(MonorailTestEnvironment).ConnectionString);
                sqlConnection.Open();

                var query =
                    "select top 1 VerificationCode from VerificationCodes join Users on Users.Id = VerificationCodes.UserId where Users.Email=\'" +
                    email + "\' order by VerificationCodes.CreateDateUtc desc";

                var command = new SqlCommand(query, sqlConnection);
                var reader = command.ExecuteReader();

                while (reader.Read()) verificationCode = reader.GetString(0);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return verificationCode;
        }
    }
}