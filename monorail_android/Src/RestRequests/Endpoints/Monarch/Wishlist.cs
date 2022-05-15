using System.Net;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_android.RestRequests.RestConfig;

namespace monorail_android.RestRequests.Endpoints.Monarch
{
    public static class Wishlist
    {
        private const string WishlistEndpoint = "/api/Wishlist/";

        public static string[] GetWishlistItemsInProgress(string token)
        {
            var client = new RestClient
            {
                BaseUrl = MonarchAppUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = WishlistEndpoint,
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            dynamic responseContent = JObject.Parse(response.Content);

            string[] wishlistItemsInProgress = responseContent.wishlistItemsInProgress.ToObject<string[]>();

            return wishlistItemsInProgress;
        }
    }
}