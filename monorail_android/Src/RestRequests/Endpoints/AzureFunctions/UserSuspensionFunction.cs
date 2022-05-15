using System.Net;
using FluentAssertions;
using RestSharp;
using static monorail_android.RestRequests.RestConfig;

namespace monorail_android.RestRequests.Endpoints.AzureFunctions
{
    public static class UserSuspensionFunction
    {
        private const string UserSuspensionFunctionEndpoint = "/api/UserSuspensionFunction";

        public static void GetUserSuspensionFunction(string userId)
        {
            var client = new RestClient
            {
                BaseUrl = AzureFunctionsUri
            };
            var request = new RestRequest
            {
                Resource = UserSuspensionFunctionEndpoint,
                Method = Method.GET
            };
            request.AddParameter("code", GetEndpointConfiguration().AzureCode);
            request.AddParameter("id", userId);

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}