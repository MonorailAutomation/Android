using monorail_android.PageObjects;
using monorail_android.PageObjects.Launch;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Wishlist;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_android.Test.Scripts.Login
{
    [TestFixture]
    public class LoginAndLogout : FunctionalTesting
    {
        [Test]
        public void LoginAndLogoutTest()
        {
            var loginPage = new LoginPage(Driver);
            var emptyMainWishlistPage = new EmptyMainWishlistPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+40.131021@gmail.com";

            VerifyPlaidConnection(username);

            GoThroughLaunchScreens();
            
            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();
            
            emptyMainWishlistPage
                .WaitUntilEmptyMainWishlistPageIsLoaded();
            
            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();
            
            logOutBottomUp
                .ClickYesButton();
        }

        public static void GoThroughLaunchScreens()
        {
            var launchWishlistPage = new LaunchWishlistPage(Driver);
            var launchPowerPage = new LaunchPowerPage(Driver);
            var launchBuyPage = new LaunchBuyPage(Driver);

            launchWishlistPage.ClickContinueButton();
            launchPowerPage.ClickContinueButton();
            launchBuyPage.ClickGetStartedButton();
        }
    }
}