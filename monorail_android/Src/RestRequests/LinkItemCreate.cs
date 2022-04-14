using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using static monorail_android.RestRequests.RestConfig;
using static monorail_android.Commons.Constants;

namespace monorail_android.RestRequests
{
    public static class LinkItemCreate
    {
        private const string LinkItemCreateEndpoint = "/link/item/create";

        public static string[] PostLinkItemCreate(string token)
        {
            var client = new RestClient
            {
                BaseUrl = PlaidUri,
                Authenticator = new JwtAuthenticator(token)
            };
            var request = new RestRequest
            {
                Resource = LinkItemCreateEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new
            {
                link_session_id = "702d1c4f-7eb2-46ee-b210-0870962008f0",
                public_key = "658663fa69ca8ed58e580a7a9cd4de",
                institution_id = "ins_3",
                credentials = new
                {
                    username = PlaidUsername,
                    password = PlaidPassword
                },
                initial_products = new List<string> {"auth", "transactions"},
                link_open_id = "06566E92-439C-45EB-93BC-37353733B9AD",
                options = new
                {
                    is_longtail_auth = false,
                    link_configuration = (string[]) null
                },
                display_language = "en"
            });

            var response = client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            dynamic responseContent = JObject.Parse(response.Content);
            var accountId = responseContent.accounts[0].account_id;
            var publicToken = responseContent.public_token;

            return new string[] {publicToken, accountId};
        }
    }
}