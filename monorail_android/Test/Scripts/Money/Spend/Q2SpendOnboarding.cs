using monorail_android.PageObjects;
using monorail_android.PageObjects.Commons.Onboarding;
using monorail_android.PageObjects.Commons.Plaid;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Money.Spend;
using monorail_android.PageObjects.Wishlist;
using NUnit.Framework;
using static monorail_android.Commons.RandomGenerator;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Helpers.UserOnboardingHelperFunctions;

namespace monorail_android.Test.Scripts.Money.Spend
{
    internal class Q2SpendOnboarding : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+23.271221";
        private const string UsernameSuffix = "@gmail.com";

        [Test]
        public void Q2SpendOnboardingTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var bottomMenu = new BottomNavigation(Driver);
            var mainSpendPage = new MainSpendPage(Driver);
            var personalInformationPage = new PersonalInformationPage(Driver);
            var firstNameLastNamePage = new FirstNameLastNamePage(Driver);
            var ssnPage = new SsnPage(Driver);
            var residentialAddressPage = new ResidentialAddressPage(Driver);
            var politicalExposureQuestionPage = new PoliticalExposureQuestionPage(Driver);
            var linkAnAccountPage = new LinkAnAccountPage(Driver);
            var plaidStartPage = new PlaidStartPage(Driver);
            var plaidSelectYourBankPage = new PlaidSelectYourBankPage(Driver);
            var plaidCredentialsPage = new PlaidCredentialsPage(Driver);
            var plaidAccountPage = new PlaidAccountPage(Driver);
            var plaidSuccessScreen = new PlaidSuccessScreen(Driver);
            var electronicDeliveryConsentPage = new ElectronicDeliveryConsentPage(Driver);
            var termsAndConditionsPage = new TermsAndConditionsPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            RegisterUser(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainWishlistPage
                .WaitUntilEmptyMainWishlistPageIsLoaded();

            bottomMenu
                .ClickMoneyNavButton();

            mainSpendPage
                .ClickOpenYourCheckingAccountButton();

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

            electronicDeliveryConsentPage
                .ScrollToTheBottomOfPage()
                .ClickAgreeAndContinueButton();

            termsAndConditionsPage
                .ScrollToTheBottomOfPage()
                .ClickAgreeAndFinishButton();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }
    }
}