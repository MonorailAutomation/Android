using monorail_android.PageObjects;
using monorail_android.PageObjects.Commons.Onboarding;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Money;
using monorail_android.PageObjects.Money.Save;
using monorail_android.PageObjects.Money.Spend;
using monorail_android.PageObjects.Wishlist;
using NUnit.Framework;
using static monorail_android.Commons.NumberGenerator;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Helpers.UserOnboardingHelperFunctions;
using static monorail_android.Test.Scripts.Transactions.ConnectPlaidToNewUser;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.Commons.EmailGenerator;

namespace monorail_android.Test.Scripts.Money.Save
{
    internal class Q2SaveOnboardingSuccesful : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+25."; 
        private const string UsernameSuffix = "@gmail.com";

        [Test]
        public void Q2SaveOnboardingSuccesfulTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var bottomMenu = new BottomNavigation(Driver);
            var spendSaveToggle = new SpendSaveToggle(Driver);
            var mainSavePage = new MainSavePage(Driver);
            var personalInformationPage = new PersonalInformationPage(Driver);
            var firstNameLastNamePage = new FirstNameLastNamePage(Driver);
            var ssnPage = new SsnPage(Driver);
            var residentialAddressPage = new ResidentialAddressPage(Driver);
            var politicalExposureQuestionPage = new PoliticalExposureQuestionPage(Driver);
            var linkAnAccountPage = new LinkAnAccountPage(Driver);
            var electronicDeliveryConsentPage = new ElectronicDeliveryConsentPage(Driver);
            var termsAndConditionsPage = new TermsAndConditionsPage(Driver);
            var mainSpendPage = new MainSpendPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            RegisterUser(username);

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainWishlistPage
                .WaitUntilEmptyMainWishlistPageIsLoaded();

            bottomMenu
                .ClickMoneyNavButton();

            spendSaveToggle
                .ClickSaveButton();

            mainSavePage
                .ClickUnlockSavingsTracks();

            personalInformationPage
                .ClickGetStartedButton();

            firstNameLastNamePage
                .PassFirstAndLastName(ValidFirstName, ValidLastName)
                .ClickContinueButton();

            ssnPage
                .PassSsn(ValidSsn)
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
                .ClickTrack("Travel")
                .ClickGetStartedButton()
                .WaitUntilTrackIsDisplayed();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }
    }
}