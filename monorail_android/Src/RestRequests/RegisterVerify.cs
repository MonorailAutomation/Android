using System.Net;
using FluentAssertions;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_android.RestRequests.RestConfig;
using static monorail_android.Commons.Constants;

namespace monorail_android.RestRequests
{
    public static class RegisterVerify
    {
        private const string RegisterEndpoint = "/api/v2/user/Register/Verify";

        public static void PostRegisterVerify(string token)
        {
            const string verificationMode = "phone";
            const string verificationCode = "111111";
            var client = new RestClient
            {
                BaseUrl = MonorailUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = RegisterEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new
            {
                otp = verificationCode,
                verificationMode,
                primaryInput = ValidPhoneNumber
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}