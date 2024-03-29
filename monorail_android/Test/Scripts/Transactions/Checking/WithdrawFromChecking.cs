using monorail_android.PageObjects;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Money.Spend;
using monorail_android.PageObjects.Wishlist;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_android.Test.Scripts.Transactions.Checking
{
    [TestFixture]
    [AllureNUnit]
    internal class WithdrawFromChecking : FunctionalTesting
    {
        [Test(Description = "Withdraw from Checking Account")]
        [AllureEpic("Transactions")]
        [AllureFeature("Spend")]
        [AllureStory("Withdraw from Checking Account")]
        public void WithdrawFromCheckingTest()
        {
            var loginPage = new LoginPage(Driver);
            var emptyMainWishlistPage = new EmptyMainWishlistPage(Driver);
            var bottomMenu = new BottomNavigation(Driver);
            var mainSpendPage = new MainSpendPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);
            var withdrawFundsPage = new WithdrawFundsPage(Driver);
            var finishWithdrawFundsPage = new FinishWithdrawFundsPage(Driver);

            const string username = "autotests.mono+8.3.051322@gmail.com";
            const string withdrawAmount = "1";

            VerifyPlaidConnection(username);

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            emptyMainWishlistPage
                .WaitUntilEmptyMainWishlistPageIsLoaded();

            bottomMenu
                .ClickMoneyNavButton();

            mainSpendPage
                .ClickCashOutButton();

            withdrawFundsPage
                .SetAmount(withdrawAmount)
                .ClickConfirmButton();

            finishWithdrawFundsPage
                .ClickReturnButton();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }
    }
}