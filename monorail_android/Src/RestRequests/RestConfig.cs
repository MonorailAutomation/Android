using System;
using Microsoft.Extensions.Configuration;
using monorail_android.Model.ConfigurationModel;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.RestRequests
{
    public static class RestConfig
    {
        public static readonly Uri MonarchAppUri =
            new Uri("https://monarch-app-" + MonorailTestEnvironment + ".azurewebsites.net");

        public static readonly Uri MonarchManagementUri =
            new Uri("https://monarchmanagement-app-" + MonorailTestEnvironment + ".azurewebsites.net");

        public static readonly Uri AzureFunctionsUri =
            new Uri("https://monarch-functionsapp-" + MonorailTestEnvironment + ".azurewebsites.net");

        public static readonly Uri PlaidUri = new Uri("https://sandbox.plaid.com");
        
        public static EndpointConfiguration GetEndpointConfiguration()
        {
            var configuration = new ConfigurationBuilder().BuildAppSettings();

            var endpointConfiguration = configuration.GetSection("EndpointConfiguration").Get<EndpointConfiguration>();

            return endpointConfiguration;
        }
    }
}