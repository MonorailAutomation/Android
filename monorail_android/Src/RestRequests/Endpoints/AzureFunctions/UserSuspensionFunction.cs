using System.Net;
using FluentAssertions;
using RestSharp;

namespace monorail_android.RestRequests.Endpoints.AzureFunctions
{
    public static class UserSuspensionFunction
    {
        private const string Code = "ZerhFEUu/zqbdJn6Pf/EYDvNcAemeEPCxvHcuIdkzQlyqqpt4qfM1g==";
        private const string UserSuspensionFunctionEndpoint = "/api/UserSuspensionFunction";

        public static void GetUserSuspensionFunction(string userId)
        {
            var client = new RestClient
            {
                BaseUrl = RestConfig.AzureFunctionsUri
            };
            var request = new RestRequest
            {
                Resource = UserSuspensionFunctionEndpoint,
                Method = Method.GET
            };
            request.AddParameter("code", Code);
            request.AddParameter("id", userId);

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}