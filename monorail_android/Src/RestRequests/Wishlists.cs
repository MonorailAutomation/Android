using System.Net;
using FluentAssertions;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_android.RestRequests.RestConfig;

namespace monorail_android.RestRequests
{
    public class Wishlists
    {
        private const string WishlistsEndpoint = "/api/Wishlists/";

        public static void AddCustomWishlistItem(string token, string productUrl, string itemName,
            string itemDescription,
            string itemAmount, string itemImageUrl, string itemFavIconUrl)
        {
            var client = new RestClient
            {
                BaseUrl = MonorailUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = WishlistsEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };

            request.AddJsonBody(new
            {
                itemUrl = productUrl,
                name = itemName,
                description = itemDescription,
                amount = itemAmount,
                imageUrl = itemImageUrl,
                favIconUrl = itemFavIconUrl
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}