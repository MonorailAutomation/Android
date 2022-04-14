using System;
using static monorail_android.RestRequests.LinkItemCreate;
using static monorail_android.RestRequests.MoneyAch;
using static monorail_android.RestRequests.Token;
using static monorail_android.RestRequests.VerifyStatus;

namespace monorail_android.RestRequests.Helpers
{
    public static class PlaidConnectionHelperFunctions
    {
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