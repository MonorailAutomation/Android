using monorail_android.DataGenerators;
using monorail_android.PageObjects;
using monorail_android.PageObjects.Commons.Onboarding;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Wishlist;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Helpers.UserOnboardingHelperFunctions;
using static monorail_android.RestRequests.Helpers.WishlistHelperFunctions;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.RestRequests.Helpers.UserManagementHelperFunctions;
using monorail_android.PageObjects.Money.Spend;
using monorail_android.PageObjects.Money;
using static monorail_android.Test.Scripts.Transactions.Plaid.ConnectPlaidToNewUser;

namespace monorail_android.Test.Scripts.Wishlist
{
    internal class WishlistOnboardingRejected : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+22.";
        private const string UsernameSuffix = "@gmail.com";

        [Test]
        public void WishlistOnboardingThroughMainWishlistScreenRejected()
        {
            var loginPage = new LoginPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
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
            var spendSaveToggle = new SpendSaveToggle(Driver);
            var mainSpendPage = new MainSpendPage(Driver);
            var bottomNavigation = new BottomNavigation(Driver);

            var username = EmailGenerator.GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            RegisterUser(username, Q2RejectedDateOfBirthYmd);
            AddPersonalizedWishlistItem(username, WishlistItemUrl, WishlistItemName,
                WishlistItemDescription, WishlistItemPrice, WishlistItemImage, WishlistItemFavicon);

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainWishlistPage
                .ClickCreateAWishlistAccountButton();

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

            /* Because of BUG: 41890
               rejected status cannot be verified on Wishlist page.
               Temporary workaround: verifying status on Spend page. 
             */

            bottomNavigation
                .ClickMoneyNavButton();

            spendSaveToggle
                .ClickSaveButton()
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