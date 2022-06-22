using monorail_android.PageObjects;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Money;
using monorail_android.PageObjects.Money.Save;
using monorail_android.PageObjects.Money.Save.ItemPages;
using monorail_android.PageObjects.Money.Save.TransactionPages;
using monorail_android.PageObjects.Invest;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_android.Test.Scripts.Transactions.Track
{
    [TestFixture]
    [AllureNUnit]
    internal class WithdrawFromTrack : FunctionalTesting
    {
        [Test(Description = "Withdraw from Track")]
        [AllureEpic("Transactions")]
        [AllureFeature("Save")]
        [AllureStory("Withdraw from Track")]
        public void WithdrawFromTrackTest()
        {
            var loginPage = new LoginPage(Driver);
            var emptyTradingPage = new EmptyTradingPage(Driver);
            var bottomMenu = new BottomNavigation(Driver);
            var spendSaveToggle = new SpendSaveToggle(Driver);
            var trackDetailsPage = new TrackDetailsPage(Driver);
            var trackWithdrawCashPage = new TrackWithdrawCashPage(Driver);
            var trackWithdrawCashFinishPage = new TrackWithdrawCashFinishPage(Driver);
            var mainSavePage = new MainSavePage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+8.4.1204221@gmail.com";
            const string trackName = "Travel";
            const string withdrawAmount = "1";

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            emptyTradingPage
                .WaitUntilEmptyTradingPageIsLoaded();

            bottomMenu
                .ClickMoneyNavButton();

            spendSaveToggle
                .ClickSaveButton();

            mainSavePage
                .ClickTrackDetails(trackName);

            trackDetailsPage
                .ClickWithdrawButton();

            trackWithdrawCashPage
                .SetAmount(withdrawAmount)
                .ClickConfirmButton();

            trackWithdrawCashFinishPage
                .ClickReturnButton();

            trackDetailsPage
                .ClickBackButton();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }
    }
}