using monorail_android.PageObjects;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Money;
using monorail_android.PageObjects.Wishlist;
using monorail_android.PageObjects.Money.Save;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_android.Test.Scripts.Transactions
{
    internal class DepositToTrack : FunctionalTesting
    {
        [Test]
        public void DepositToTrackThroughtAddFundsOnTrackDetailsScreenTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);
            var emptyMainWishlistPage = new EmptyMainWishlistPage(Driver);
            var bottomMenu = new BottomNavigation(Driver);
            var spendSaveToggle = new SpendSaveToggle(Driver);
            var mainSavePage = new MainSavePage(Driver);
            var trackDetailsPage = new TrackDetailsPage(Driver);
            var trackAddFundsPage = new TrackAddFundsPage(Driver);
            var trackAddFundsFinishPage = new TrackAddFundsFinishPage(Driver);

            const string username = "autotests.mono+7.4.051322@gmail.com";
            const string trackName = "Travel";
            const string depositAmount = "10";

            VerifyPlaidConnection(username);

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
                .ClickAddFundsButton();

            trackAddFundsPage
                .RemoveDefaultAmount()
                .SetAmount(depositAmount)
                .ClickConfirmButton();

            trackAddFundsFinishPage
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