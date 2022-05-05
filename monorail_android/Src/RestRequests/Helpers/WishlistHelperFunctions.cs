using static monorail_android.RestRequests.Token;
using static monorail_android.RestRequests.Endpoints.Monarch.Wishlists;

namespace monorail_android.RestRequests.Helpers
{
    public static class WishlistHelperFunctions
    {
        public static void AddPersonalizedWishlistItem(string username, string productUrl,
            string itemName, string itemDescription, string itemAmount, string itemImageUrl, string itemFavIconUrl)
        {
            var token = GenerateToken(username);
            AddCustomWishlistItem(token, productUrl, itemName, itemDescription, itemAmount, itemImageUrl,
                itemFavIconUrl);
        }
    }
}