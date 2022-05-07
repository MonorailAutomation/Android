using System.Threading;
using static monorail_android.RestRequests.Endpoints.Monarch.Token;
using static monorail_android.RestRequests.Endpoints.Monarch.Wishlists;

namespace monorail_android.RestRequests.Helpers
{
    public static class WishlistHelperFunctions
    {
        public static void AddPersonalizedWishlistItem(string username, string productUrl,
            string itemName, string itemDescription, string itemPrice, string itemImageUrl, string itemFavIconUrl)
        {
            var token = GenerateToken(username);
            AddCustomWishlistItem(token, productUrl, itemName, itemDescription, itemPrice, itemImageUrl,
                itemFavIconUrl);
            WaitUntilItemsAreScraped(token);
        }

        private static void WaitUntilItemsAreScraped(string token)
        {
            string[] wishlistItemsInProgress;
            do
            {
                wishlistItemsInProgress = GetWishlistItemsInProgress(token);
                Thread.Sleep(3000);
            } while (wishlistItemsInProgress.Length > 0);
        }
    }
}