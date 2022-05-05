using System;
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
    }
}