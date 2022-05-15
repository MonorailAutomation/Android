using System;
using static monorail_android.RestRequests.Endpoints.Plaid.LinkItemCreate;
using static monorail_android.RestRequests.Endpoints.Monarch.MoneyAch;
using static monorail_android.RestRequests.Endpoints.Monarch.Token;
using static monorail_android.RestRequests.Endpoints.Monarch.VerifyStatus;
using NUnit.Allure.Attributes;

namespace monorail_android.RestRequests.Helpers
{
    public static class PlaidConnectionHelperFunctions
    {
        [AllureStep("Verify Plaid account connection using REST endpoint")]
        public static void VerifyPlaidConnection(string username)
        {
            var token = GenerateToken(username);
            var verifyStatus = GetVerifyStatus(token);
            if (verifyStatus.Equals("OK")) return;

            Console.WriteLine("Reconnecting Plaid account");
            var plaidData = PostLinkItemCreate(username);
            PostMoneyAch(token, plaidData[0], plaidData[1]);
        }
    }
}