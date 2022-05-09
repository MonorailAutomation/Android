using System;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Endpoints.Monarch.Register;
using static monorail_android.RestRequests.Endpoints.Monarch.Token;
using static monorail_android.RestRequests.Endpoints.Monarch.RegisterVerify;
using static monorail_android.RestRequests.Endpoints.Monarch.TermsOfUse;

namespace monorail_android.RestRequests.Helpers
{
    public static class UserOnboardingHelperFunctions
    {
        public static void RegisterUser(string username)
        {
            PostRegister(username, ValidPhoneNumber, ValidDateOfBirthYmd);
            var token = GenerateToken(username);
            PostRegisterVerify(token);
            var termsOfUseId = GetTermsOfUseId(token);
            PostTermsOfUse(token, termsOfUseId);
            Console.WriteLine(username + " was created successfully");
        }

        public static void RegisterUser(string username, string dateOfBirth)
        {
            PostRegister(username, ValidPhoneNumber, dateOfBirth);
            var token = GenerateToken(username);
            PostRegisterVerify(token);
            var termsOfUseId = GetTermsOfUseId(token);
            PostTermsOfUse(token, termsOfUseId);
            Console.WriteLine(username + " was created successfully");
        }
    }
}