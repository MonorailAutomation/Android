using static monorail_android.Commons.NumberGenerator;
using static monorail_android.RestRequests.VerifyEmailAddress;

namespace monorail_android.Commons
{
    public static class EmailGenerator
    {
        public static string GenerateNewEmail(string usernamePrefix, string usernameSuffix)
        {
            string username;
            bool emailAlreadyExists;
            do
            {
                username = usernamePrefix + GetCurrentDate() + "." + GenerateRandom4Digits() + usernameSuffix;
                emailAlreadyExists = VerifyEmailAlreadyExists(username);
            } while (emailAlreadyExists);

            return username;
        }
    }
}