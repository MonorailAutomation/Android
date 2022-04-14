using System;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_android.RestRequests.RestConfig;

namespace monorail_android.RestRequests
{
    public static class VerifyStatus
    {
        private const string VerifyStatusEndpoint = "/api/accounts/plaid/VerifyStatus";

        public static string GetVerifyStatus(string token)
        {
            var client = new RestClient
            {
                BaseUrl = MonorailUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = VerifyStatusEndpoint,
                Method = Method.GET
            };

            var response = client.Execute(request);

            Console.WriteLine("Plaid Account status: " + response.StatusCode);

            return response.StatusCode.ToString();
        }
    }
}