using Newtonsoft.Json.Linq;
using RestSharp;
using static monorail_android.RestRequests.RestConfig;
using static monorail_android.Commons.Constants;

namespace monorail_android.RestRequests.Endpoints.Monarch
{
    public static class Token
    {
        private const string TokenEndpoint = "/api/token";

        public static string GenerateToken(string user)
        {
            var client = new RestClient(MonarchAppUri);
            var request = new RestRequest
            {
                Resource = TokenEndpoint,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new {email = user, password = ValidPassword});

            var response = client.Execute(request);

            dynamic responseContent = JObject.Parse(response.Content);

            return responseContent.accessToken;
        }
    }
}