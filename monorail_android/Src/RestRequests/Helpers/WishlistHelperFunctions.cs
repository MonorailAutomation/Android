using System.Threading;
using NUnit.Allure.Attributes;
using static monorail_android.Database.WishlistItem;
using static monorail_android.RestRequests.Endpoints.Monarch.Token;
using static monorail_android.RestRequests.Endpoints.Monarch.Wishlists;
using static monorail_android.RestRequests.Endpoints.Monarch.Wishlist;

namespace monorail_android.RestRequests.Helpers
{
    public static class WishlistHelperFunctions
    {
        [AllureStep("Add Wishlist item using REST endpoint")]
        public static void AddPersonalizedWishlistItem(string username, string productUrl, string itemName,
            string itemDescription, string itemPrice, string itemImageUrl, string itemFavIconUrl)
        {
            var token = GenerateToken(username);
            AddCustomWishlistItem(token, productUrl, itemName, itemDescription, itemPrice, itemImageUrl,
                itemFavIconUrl);
            WaitUntilItemsAreScraped(token);
        }

        [AllureStep("Edit Wishlist item using REST endpoint")]
        public static void EditWishlistItem(string username, string spotId, string itemName,
    string itemDescription, string itemPrice)
        {
            var token = GenerateToken(username);
            EditWishlistItemDetails(token, spotId, itemName, itemDescription, itemPrice);
        }

        [AllureStep("Add empty Wishlist item using REST endpoint")]
        public static void AddEmptyWishlistItem(string username, string productUrl)
        {
            var token = GenerateToken(username);
            var wishlistItemId = AddCustomWishlistItem(token, productUrl, null, null,
                null, null, null);
            WaitUntilItemsAreScraped(token);
            ClearWishlistItem(wishlistItemId);
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