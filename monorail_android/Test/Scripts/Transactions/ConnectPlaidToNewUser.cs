using monorail_android.PageObjects;
using monorail_android.PageObjects.Commons.Plaid;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Wishlist;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Helpers.UserOnboardingHelperFunctions;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.Commons.EmailGenerator;
using static monorail_android.RestRequests.Helpers.UserManagementHelperFunctions;

namespace monorail_android.Test.Scripts.Transactions
{
    internal class ConnectPlaidToNewUser : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+20.";
        private const string UsernameSuffix = "@gmail.com";

        [Test]
        public void ConnectPlaidToNewUserTest()
        {
            var loginPage = new LoginPage(Driver);
            var emptyMainWishlistPage = new EmptyMainWishlistPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var connectedAccountPage = new ConnectedAccountPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            RegisterUser(username);

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            emptyMainWishlistPage
                .WaitUntilEmptyMainWishlistPageIsLoaded();

            mainMenuPage
                .ClickSideMenu()
                .ClickMyConnectedAccount();

            connectedAccountPage
                .ClickConnectYourAccountButton();

            ConnectPlaid();

            connectedAccountPage
                .WaitUntilConnectedAccountPageAfterConnectingPlaidIsLoaded()
                .ClickBackButton();

            mainMenuPage
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();

            CloseUser(username);
        }

        public static void ConnectPlaid()
        {
            var plaidStartPage = new PlaidStartPage(Driver);
            var plaidSelectYourBankPage = new PlaidSelectYourBankPage(Driver);
            var plaidCredentialsPage = new PlaidCredentialsPage(Driver);
            var plaidAccountPage = new PlaidAccountPage(Driver);
            var plaidSuccessScreen = new PlaidSuccessScreen(Driver);

            plaidStartPage
                .ClickContinueButton();

            plaidSelectYourBankPage
                .ClickBank("Chase");

            plaidCredentialsPage
                .PassCredentials()
                .ClickSubmitButton();

            plaidAccountPage
                .SelectPrimaryAccount("Checking")
                .ClickContinueButton();

            plaidSuccessScreen
                .ClickContinueButton();
        }
    }
}