using monorail_android.PageObjects;
using monorail_android.PageObjects.Commons.Onboarding;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Money.Spend;
using monorail_android.PageObjects.Invest;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Helpers.UserOnboardingHelperFunctions;
using static monorail_android.Test.Scripts.Transactions.Plaid.ConnectPlaidToNewUser;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.DataGenerators.EmailGenerator;
using static monorail_android.RestRequests.Helpers.UserManagementHelperFunctions;

namespace monorail_android.Test.Scripts.Money.Spend.Onboarding
{
    [TestFixture]
    [AllureNUnit]
    internal class Q2SpendOnboarding : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+23.";
        private const string UsernameSuffix = "@gmail.com";

        [Test(Description = "Q2 Spend Onboarding - successful")]
        [AllureEpic("Money")]
        [AllureFeature("Spend")]
        [AllureStory("Q2 Spend Onboarding - successful")]
        public void Q2SpendOnboardingSuccessfulTest()
        {
            var loginPage = new LoginPage(Driver);
            var emptyMilestonesPage = new EmptyMilestonesPage(Driver);
            var bottomMenu = new BottomNavigation(Driver);
            var emptyMainSpendPage = new EmptyMainSpendPage(Driver);
            var personalInformationPage = new PersonalInformationPage(Driver);
            var firstNameLastNamePage = new FirstNameLastNamePage(Driver);
            var ssnPage = new SsnPage(Driver);
            var residentialAddressPage = new ResidentialAddressPage(Driver);
            var politicalExposureQuestionPage = new PoliticalExposureQuestionPage(Driver);
            var linkAnAccountPage = new LinkAnAccountPage(Driver);
            var electronicDeliveryConsentPage = new ElectronicDeliveryConsentPage(Driver);
            var termsAndConditionsPage = new TermsAndConditionsPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            RegisterUser(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            emptyMilestonesPage
                .WaitUntilEmptyMilestonesPageIsLoaded();

            bottomMenu
                .ClickMoneyNavButton();

            emptyMainSpendPage
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

            ConnectPlaid();

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

            CloseUser(username);
        }
    }
}