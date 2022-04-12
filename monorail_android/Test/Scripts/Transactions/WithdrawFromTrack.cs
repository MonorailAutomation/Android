using monorail_android.PageObjects;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Money;
using monorail_android.PageObjects.Money.Save;
using monorail_android.PageObjects.Wishlist;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;

namespace monorail_android.Test.Scripts.Transactions
{
    internal class WithdrawFromTrack : FunctionalTesting
    {
        [Test]
        public void WithdrawFromTrackTest()
        {
            var loginPage = new LoginPage(Driver);
            var emptyMainWishlistPage = new EmptyMainWishlistPage(Driver);
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

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            emptyMainWishlistPage
                .WaitUntilEmptyMainWishlistPageIsLoaded();

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