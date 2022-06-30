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

namespace monorail_android.Test.Scripts.Money.Spend.Onboarding
{
    [TestFixture]
    [AllureNUnit]
    internal class Q2SpendOnboardingManualReview : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+23.";
        private const string UsernameSuffix = "@gmail.com";

        [Test(Description = "Q2 Spend Onboarding - account in 'Manual Review'")]
        [AllureEpic("Money")]
        [AllureFeature("Spend")]
        [AllureStory("Q2 Spend Onboarding - account in 'Manual Review'")]
        public void Q2SpendOnboardingManualReviewTest()
        {
            var loginPage = new LoginPage(Driver);
            var emptyMilestonesPage = new EmptyMilestonesPage(Driver);
            var bottomMenu = new BottomNavigation(Driver);
            var emptyMainSpendPage = new EmptyMainSpendPage(Driver);
            var mainSpendPage = new MainSpendPage(Driver);
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
            var bottomUpModal = new BottomUpModal(Driver);

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            RegisterUser(username, Q2RejectedDateOfBirthYmd);

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
                .PassFirstAndLastName(Q2RejectedManualReviewFirstName, Q2RejectedManualReviewLastName)
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

            bottomUpModal
                .ClickDismissButton();

            /* Because of BUG: 41237
            manual review status cannot be verified right after account creation.
            Temporary workaround: re-login. 
            */
            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            emptyMilestonesPage
                .WaitUntilEmptyMilestonesPageIsLoaded();

            bottomMenu
                .ClickMoneyNavButton();

            mainSpendPage
                .WaitUntilManualReviewAccountStatusIsDisplayed();


            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }
    }
}