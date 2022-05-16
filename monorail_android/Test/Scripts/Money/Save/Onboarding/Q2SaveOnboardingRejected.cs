using monorail_android.PageObjects;
using monorail_android.PageObjects.Commons.Onboarding;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Money;
using monorail_android.PageObjects.Money.Save;
using monorail_android.PageObjects.Money.Spend;
using monorail_android.PageObjects.Wishlist;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Helpers.UserOnboardingHelperFunctions;
using static monorail_android.Test.Scripts.Transactions.Plaid.ConnectPlaidToNewUser;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.DataGenerators.EmailGenerator;
using static monorail_android.RestRequests.Helpers.UserManagementHelperFunctions;

namespace monorail_android.Test.Scripts.Money.Save.Onboarding
{
    [TestFixture]
    [AllureNUnit]
    internal class Q2SaveOnboardingRejected : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+25.";
        private const string UsernameSuffix = "@gmail.com";

        [Test(Description = "Q2 Save Onboarding - account rejected")]
        [AllureEpic("Money")]
        [AllureFeature("Save")]
        [AllureStory("Q2 Save Onboarding - account rejected")]
        public void Q2SaveOnboardingRejectedTest()
        {
            var loginPage = new LoginPage(Driver);
            var emptyMainWishlistPage = new EmptyMainWishlistPage(Driver);
            var bottomMenu = new BottomNavigation(Driver);
            var spendSaveToggle = new SpendSaveToggle(Driver);
            var emptyMainSavePage = new EmptyMainSavePage(Driver);
            var personalInformationPage = new PersonalInformationPage(Driver);
            var firstNameLastNamePage = new FirstNameLastNamePage(Driver);
            var ssnPage = new SsnPage(Driver);
            var residentialAddressPage = new ResidentialAddressPage(Driver);
            var politicalExposureQuestionPage = new PoliticalExposureQuestionPage(Driver);
            var linkAnAccountPage = new LinkAnAccountPage(Driver);
            var electronicDeliveryConsentPage = new ElectronicDeliveryConsentPage(Driver);
            var termsAndConditionsPage = new TermsAndConditionsPage(Driver);
            var mainSavePage = new MainSavePage(Driver);
            var mainSpendPage = new MainSpendPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            RegisterUser(username, Q2RejectedDateOfBirthYmd);

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

            emptyMainSavePage
                .ClickUnlockSavingsTracks();

            personalInformationPage
                .ClickGetStartedButton();

            firstNameLastNamePage
                .PassFirstAndLastName(Q2RejectedManualReviewFirstName, Q2RejectedManualReviewLastName)
                .ClickContinueButton();

            ssnPage
                .PassSsn(Q2RejectedSsn)
                .ClickContinueButton();

            residentialAddressPage
                .PassAddress(ValidAddressLine1, ValidCity, ValidState, ValidZip)
                .ClickContinueButton();

            politicalExposureQuestionPage
                .ClickNopeAnswer()
                .ClickContinueButton();

            linkAnAccountPage
                .ClickLinkYourAccountButton();

            ConnectPlaid();

            electronicDeliveryConsentPage
                .ScrollToTheBottomOfPage()
                .ClickAgreeAndContinueButton();

            termsAndConditionsPage
                .ScrollToTheBottomOfPage()
                .ClickAgreeAndFinishButton();

            mainSavePage
                .ClickTrackTile("Travel")
                .ClickGetStartedButton();

            /* Because of BUG: 37760
               rejected status cannot be verified on Save page.
               Temporary workaround: verifying status on Spend page. 
             */

            spendSaveToggle
                .ClickSpendButton();

            mainSpendPage
                .WaitUntilRejectedAccountStatusIsDisplayed();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();

            CloseUser(username);
        }
    }
}