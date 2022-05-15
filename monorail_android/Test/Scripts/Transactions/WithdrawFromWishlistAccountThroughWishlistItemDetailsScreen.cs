using monorail_android.PageObjects;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Wishlist;
using monorail_android.PageObjects.Wishlist.ItemPages;
using monorail_android.PageObjects.Wishlist.TransactionPages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.Commons.Scroll;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.RestRequests.Helpers.PlaidConnectionHelperFunctions;
using static monorail_android.RestRequests.Helpers.WishlistHelperFunctions;

namespace monorail_android.Test.Scripts.Transactions
{
    [TestFixture]
    [AllureNUnit]
    internal class WithdrawFromWishlistAccountThroughWishlistItemDetailsScreen : FunctionalTesting
    {
        [Test(Description =
            "Withdraw money (external) from Wishlist Account using 'Ready to Buy' button on 'Wishlist Item Details' screen")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory(
            "Withdraw money (external) from Wishlist Account using 'Ready to Buy' button on 'Wishlist Item Details' screen")]
        public void WithdrawFromWishlistAccountThroughWishlistItemDetailsScreenExternalTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var wishlistItemDetailsPage = new WishlistItemDetailsPage(Driver);
            var transferYourFundsPage = new TransferYourFundsPage(Driver);
            var transferringPage = new TransferringPage(Driver);
            var removeFromWishlistBottomUp = new RemoveFromWishlistBottomUp(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+7.5.050622@gmail.com";

            AddPersonalizedWishlistItem(username, WishlistItemUrl, WishlistItemName, WishlistItemDescription,
                WishlistItemPrice, WishlistItemImage, WishlistItemFavicon);

            VerifyPlaidConnection(username);

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainWishlistPage
                .ClickWishlistItem(WishlistItemName);

            wishlistItemDetailsPage
                .ClickReadyToBuyButton();

            transferYourFundsPage
                .ClickExternalBankAccountOption()
                .ClickContinueButton();

            transferringPage
                .ClickConfirmButton();

            wishlistItemDetailsPage
                .WaitUntilWishlistItemDetailsPageForFundsTransferringStateIsLoaded();

            ScrollHalfOfScreen();

            wishlistItemDetailsPage
                .CheckTransferringStatusForExternalTransfer(WishlistItemPrice)
                .ClickBackButton();

            mainWishlistPage
                .CheckStatusPillForWishlistItem(WishlistItemName, "Funds Transferring")
                .ClickWishlistItem(WishlistItemName);

            wishlistItemDetailsPage
                .ClickRemoveButton();

            removeFromWishlistBottomUp
                .ClickRemoveButton();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }
    }
}