using System.Net;
using FluentAssertions;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_android.RestRequests.RestConfig;

namespace monorail_android.RestRequests.Endpoints.Monarch
{
    public static class MoneyAch
    {
        private const string MoneyAchEndpoint = "/api/Money/ACH";

        public static void PostMoneyAch(string token, string generatedPlaidPublicToken, string generatedPlaidAccountId)
        {
            var client = new RestClient
            {
                BaseUrl = MonarchAppUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = MoneyAchEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new
            {
                accountName = "Plaid Checking",
                plaidPublicToken = generatedPlaidPublicToken,
                institutionId = "ins_3",
                institutionName = "Chase",
                accountSubType = "checking",
                plaidAccountId = generatedPlaidAccountId
            });
            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}