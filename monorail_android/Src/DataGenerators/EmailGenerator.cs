using static monorail_android.DataGenerators.NumberGenerator;
using static monorail_android.DataGenerators.DateGenerator;
using static monorail_android.RestRequests.Endpoints.Monarch.VerifyEmailAddress;

namespace monorail_android.DataGenerators
{
    public static class EmailGenerator
    {
        public static string GenerateNewEmail(string usernamePrefix, string usernameSuffix)
        {
            string username;
            bool emailAlreadyExists;
            do
            {
                username = usernamePrefix + GetCurrentDatePlain() + "." + GenerateRandomDigits(4) + usernameSuffix;
                emailAlreadyExists = VerifyEmailAlreadyExists(username);
            } while (emailAlreadyExists);

            return username;
        }
    }
}