using FluentAssertions;
using RestSharp;
using static monorail_android.RestRequests.RestConfig;
using Newtonsoft.Json.Linq;

namespace monorail_android.RestRequests
{
    public static class VerifyEmailAddress
    {
        private const string VerifyEmailAddressEndpoint = "/api/user/VerifyEmailAddress";

        public static bool VerifyEmailAlreadyExists(string userEmail)
        {
            var client = new RestClient
            {
                BaseUrl = MonorailUri
            };
            var request = new RestRequest
            {
                Resource = VerifyEmailAddressEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new
            {
                email = userEmail,
            });

            var response = client.Execute(request);

            dynamic responseContent = JObject.Parse(response.Content);

            return responseContent.emailExist;
        }
    }
}