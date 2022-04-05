using System.Net;
using FluentAssertions;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_android.RestRequests.RestConfig;

namespace monorail_android.RestRequests
{
    public static class Q2Goals
    {
        private const string Q2GoalsEndpoint = "/api/Q2/Goals";

        public static void DeleteTrack(string token, string spotId)
        {
            var resource = Q2GoalsEndpoint + "?spotId=" + spotId;
            var client = new RestClient
            {
                BaseUrl = MonorailUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.DELETE
            };

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}