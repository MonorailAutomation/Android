using System;
using NUnit.Allure.Attributes;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Endpoints.Monarch.V3.Register;
using static monorail_android.RestRequests.Endpoints.Monarch.Token;
using static monorail_android.RestRequests.Endpoints.Monarch.V2.RegisterVerify;
using static monorail_android.RestRequests.Endpoints.Monarch.V2.TermsOfUse;

namespace monorail_android.RestRequests.Helpers
{
    public static class UserOnboardingHelperFunctions
    {
        [AllureStep("Register user with email: '{0}' using REST endpoint")]
        public static void RegisterUser(string username)
        {
            PostRegister(username, ValidPhoneNumber, ValidDateOfBirthYmd);
            var token = GenerateToken(username);
            PostRegisterVerify(token);
            var termsOfUseId = GetTermsOfUseId(token);
            PostTermsOfUse(token, termsOfUseId);
            Console.WriteLine(username + " was created successfully");
        }

        [AllureStep("Register user with email: '{0}' and date of birth: '{1}' using REST endpoint")]
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