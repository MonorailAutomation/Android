using monorail_android.PageObjects;
using monorail_android.PageObjects.Launch;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Invest;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_android.Test.Scripts.Login
{
    [TestFixture]
    [AllureNUnit]
    public class LoginAndLogout : FunctionalTesting
    {
        [Test(Description = "Successful login with correct username and password")]
        [AllureEpic("Login")]
        [AllureFeature("Successful Login")]
        [AllureStory("Valid Login and Logout Test")]
        public void LoginAndLogoutTest()
        {
            var loginPage = new LoginPage(Driver);
            var emptyMilestonesPage = new EmptyMilestonesPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+40.131021@gmail.com";

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            emptyMilestonesPage
                .WaitUntilEmptyMilestonesPageIsLoaded();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }

        [AllureStep("Go through Launch Screens")]
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