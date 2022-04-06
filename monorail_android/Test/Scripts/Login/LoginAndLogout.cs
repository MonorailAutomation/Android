using monorail_android.PageObjects;
using monorail_android.PageObjects.Launch;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Wishlist;
using NUnit.Framework;
using static monorail_android.Commons.Constants;

namespace monorail_android.Test.Scripts.Login
{
    [TestFixture]
    public class LoginAndLogout : FunctionalTesting
    {
        [Test]
        public void LoginAndLogoutTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials("autotests.mono+40.131021@gmail.com", ValidPassword)
                .ClickSignInButton();

            mainWishlistPage
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