using FluentAssertions;
using RestSharp;
using static System.Net.HttpStatusCode;
using static monorail_android.RestRequests.RestConfig;

namespace monorail_android.RestRequests.Endpoints.Management
{
    public static class CloseMonorailAccount
    {
        private const string ApiKey = "0oq1Oj2R6kJNrUX1inqyOjYJtoqbtmJx";
        private const string CloseMonorailAccountEndpoint = "/api/intervention/accounts/monorail/close/";

        public static void PostMonorailCloseUserId(string userId)
        {
            var resource = CloseMonorailAccountEndpoint + userId;
            var client = new RestClient
            {
                BaseUrl = MonarchManagementUri
            };
            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.POST
            };
            request.AddHeader("apiKey", ApiKey);

            var response = client.Execute(request);

            response.StatusCode.Should().Be(OK);
        }
    }
}