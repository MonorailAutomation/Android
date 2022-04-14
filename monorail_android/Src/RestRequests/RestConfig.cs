using System;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.RestRequests
{
    public static class RestConfig
    {
        public static readonly Uri MonorailUri =
            new Uri("https://monarch-app-" + MonorailTestEnvironment + ".azurewebsites.net");

        public static readonly Uri PlaidUri = new Uri("https://sandbox.plaid.com");
    }
}