using monorail_android.PageObjects;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Wishlist;
using monorail_android.PageObjects.Wishlist.ItemPages;
using monorail_android.PageObjects.Wishlist.TransactionPages;
using static monorail_android.Commons.Scroll;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_android.Test.Scripts.Transactions.Wishlist
{
    [TestFixture]
    [AllureNUnit]
    internal class DepositToWishlist : FunctionalTesting
    {
        [Test(Description =
            "Deposit Money to Wishlist Account from Wishlist Item Details screen using 'Fund your Wishlist' button")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Deposit to Wishlist Account | Wishlist Item Details Screen -> Fund your Wishlist")]
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

            VerifyPlaidConnection(username);

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

        [Test(Description =
     "Deposit Money to Wishlist Account from Manage Wishlist screen using 'Add Cash' button")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Deposit to Wishlist Account | Manage Wishlist Screen -> Add Cash")]
        public void DepositToWishlistThroughAddCashButtonTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistAddCashPage = new WishlistAddCashPage(Driver);
            var wishlistFinishAddCashPage = new WishlistFinishAddCashPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var wishlistManagePage = new WishlistManagePage(Driver);

            const string username = "autotests.mono+7.5.051722@gmail.com";

            VerifyPlaidConnection(username);

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainWishlistPage
                .WaitUntilMainWishlistPageIsLoaded();

            ScrollHalfOfScreen();

            mainWishlistPage
                .ClickManageButton();

            wishlistManagePage
                .WaitUntilWishlistManagePageIsLoaded()
                .ClickAddAnCashButton();


            wishlistAddCashPage
                .WaitUntilWishlistAddCashPageIsLoaded()
                .SetAmount("8")
                .ClickContinueButton();

            wishlistFinishAddCashPage
                .ClickFinishButton();

            wishlistManagePage
                .WaitUntilWishlistManagePageIsLoaded()
                .ClickBackButton();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }
    }
}