using System.Net;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_android.RestRequests.RestConfig;

namespace monorail_android.RestRequests.Endpoints.Monarch
{
    public static class Wishlists
    {
        private const string WishlistsEndpoint = "/api/Wishlists/";
        private const string WishlistEndpoint = "/api/Wishlist/";

        public static string AddCustomWishlistItem(string token, string productUrl, string itemName,
            string itemDescription, string itemAmount, string itemImageUrl, string itemFavIconUrl)
        {
            var client = new RestClient
            {
                BaseUrl = MonarchAppUri,
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

            dynamic responseContent = JObject.Parse(response.Content);

            return responseContent.id;
        }

        public static void EditWishlistItemDetails(string token, string spotId, string itemName, string itemDescription, string itemPrice)
        {
            var client = new RestClient
            {
                BaseUrl = MonarchAppUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = WishlistsEndpoint,
                Method = Method.PATCH,
                RequestFormat = DataFormat.Json
            };

            request.AddJsonBody(new
            {
                id = spotId,
                name = itemName,
                description = itemDescription,
                amount = itemPrice,
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}