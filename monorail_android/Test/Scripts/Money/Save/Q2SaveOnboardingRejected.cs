using monorail_android.PageObjects;
using monorail_android.PageObjects.Commons.Onboarding;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Money;
using monorail_android.PageObjects.Money.Save;
using monorail_android.PageObjects.Money.Spend;
using monorail_android.PageObjects.Wishlist;
using NUnit.Framework;
using static monorail_android.Commons.RandomGenerator;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Helpers.UserOnboardingHelperFunctions;
using static monorail_android.Test.Scripts.Transactions.ConnectPlaidToNewUser;

namespace monorail_android.Test.Scripts.Money.Save
{
    internal class Q2SaveOnboardingRejected : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+25.2503221";
        private const string UsernameSuffix = "@gmail.com";

        [Test]
        public void Q2SaveOnboardingRejectedTest()
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

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            RegisterUser(username, Q2RejectedDateOfBirthYmd);

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
                .ClickTrack("Food")
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
        }
    }
}