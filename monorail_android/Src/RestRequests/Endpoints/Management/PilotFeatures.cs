using FluentAssertions;
using RestSharp;
using static System.Net.HttpStatusCode;
using static monorail_android.RestRequests.RestConfig;

namespace monorail_android.RestRequests.Endpoints.Management
{
    public static class PilotFeatures
    {
        public static void AddUserToPilot(string email, string type)
        {
            var resource = "/api/System/PilotFeatures";
            var client = new RestClient
            {
                BaseUrl = MonarchManagementUri
            };
            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.POST,
            };
            request.AddHeader("apiKey", GetEndpointConfiguration().MonarchApiKey);
            request.AddJsonBody(new
            {
                userEmail = email,
                type = type,
                isActive = true
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(OK);
        }
    }
}