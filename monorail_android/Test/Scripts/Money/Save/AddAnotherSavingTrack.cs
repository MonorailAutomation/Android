using monorail_android.PageObjects;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Money;
using monorail_android.PageObjects.Money.Save;
using NUnit.Framework;
using static monorail_android.Commons.RandomGenerator;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Helpers.TrackHelperFunctions;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using System.Threading;

namespace monorail_android.Test.Scripts.Money.Save
{
    internal class AddAnotherSavingTrack : FunctionalTesting
    {
        [Test]
        public void AddTrackWithTargetAmountTargetDateAndScheduledDepositTest()
        {
            var loginPage = new LoginPage(Driver);
            var bottomMenu = new BottomNavigation(Driver);
            var spendSaveToggle = new SpendSaveToggle(Driver);
            var mainSavePage = new MainSavePage(Driver);
            var chooseATrackPage = new ChooseATrackPage(Driver);
            var editTrackDetailsScreen = new EditTrackDetailsPage(Driver);
            var editTrackName = new EditTrackName(Driver);
            var targetsAndSchedulePage = new TargetsAndSchedulePage(Driver);
            var finishAddSavingTrackPage = new FinishAddSavingTrackPage(Driver);
            var editTargetDatePage = new EditTargetDatePage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+2.2.310322@gmail.com";

            var trackName = "Test Track " + GenerateRandomString();

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            bottomMenu
                .ClickMoneyNavButton();

            spendSaveToggle
                .ClickSaveButton();

            mainSavePage
                .ClickAddASavingTrackButton();

            chooseATrackPage
                .ClickTravelTrack();

            editTrackDetailsScreen
                .ClickEditTrackName();

            editTrackName
                .SetTrackName(trackName)
                .ClickSaveButton();

            editTrackDetailsScreen
                .ClickContinueButton();

            targetsAndSchedulePage
                .ClickTargetDateField();

            editTargetDatePage
                .ClickSaveButton();

            targetsAndSchedulePage
                .ClickContinueButton();

            finishAddSavingTrackPage
                .ClickContinueButton();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();

            RemoveTrack(username, trackName);
        }

        [Test]
        public void AddTrackWithoutTargetAmountTargetDateAndScheduledDepositTest()
        {
            var loginPage = new LoginPage(Driver);
            var bottomMenu = new BottomNavigation(Driver);
            var spendSaveToggle = new SpendSaveToggle(Driver);
            var mainSavePage = new MainSavePage(Driver);
            var chooseATrackPage = new ChooseATrackPage(Driver);
            var editTrackDetailsScreen = new EditTrackDetailsPage(Driver);
            var editTrackName = new EditTrackName(Driver);
            var targetsAndSchedulePage = new TargetsAndSchedulePage(Driver);
            var finishAddSavingTrackPage = new FinishAddSavingTrackPage(Driver);
            var editTargetAmountPage = new EditTargetAmountPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+2.2.041122@gmail.com";

            var trackName = "Test Track " + GenerateRandomString();

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            bottomMenu
                .ClickMoneyNavButton();

            spendSaveToggle
                .ClickSaveButton();

            mainSavePage
                .ClickAddASavingTrackButton();

            chooseATrackPage
                .ClickTravelTrack();

            editTrackDetailsScreen
                .ClickEditTrackName();

            editTrackName
                .SetTrackName(trackName)
                .ClickSaveButton();

            editTrackDetailsScreen
                .ClickContinueButton();

            targetsAndSchedulePage
                .ClickTargetAmountField();

            editTargetAmountPage
                .ClickNoTargetAmountForThisGoalButton();

            targetsAndSchedulePage
                .DisableScheduledDeposit();

            targetsAndSchedulePage
                .ClickContinueButton();

            finishAddSavingTrackPage
                .ClickContinueButton();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();

            RemoveTrack(username, trackName);
        }
    }
}