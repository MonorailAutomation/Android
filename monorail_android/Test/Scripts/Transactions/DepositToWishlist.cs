using monorail_android.PageObjects;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Wishlist;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;

namespace monorail_android.Test.Scripts.Transactions
{
    internal class DepositToWishlist : FunctionalTesting
    {
        [Test]
        public void DepositToWishlistThroughFundYourWishlistButtonTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var wishlistItemDetailsPage = new WishlistItemDetailsPage(Driver);
            var wishlistAddCashPage = new WishlistAddCashPage(Driver);
            var wishlistFinishAddCashPage = new WishlistFinishAddCashPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono.7.5.040522@gmail.com";
            const string wishlistItemName = "Test Item";

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainWishlistPage
                .ClickWishlistItem(wishlistItemName);

            wishlistItemDetailsPage
                .WaitUntilWishlistItemDetailsPageForNotReadyToBuyStateIsLoaded()
                .ClickFundYourWishlistButton();

            wishlistAddCashPage
                .WaitUntilWishlistAddCashPageIsLoaded()
                .SetAmount("7")
                .ClickContinueButton();

            wishlistFinishAddCashPage
                .ClickFinishButton();

            wishlistItemDetailsPage
                .WaitUntilWishlistItemDetailsPageForNotReadyToBuyStateIsLoaded()
                .ClickBackButton();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }
    }
}