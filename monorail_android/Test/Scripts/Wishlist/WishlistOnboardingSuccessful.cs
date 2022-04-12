using System.Threading;
using monorail_android.PageObjects;
using monorail_android.PageObjects.Commons.Onboarding;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Wishlist;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Helpers.UserOnboardingHelperFunctions;
using static monorail_android.Test.Scripts.Transactions.ConnectPlaidToNewUser;
using static monorail_android.RestRequests.Helpers.WishlistHelperFunctions;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.Commons.EmailGenerator;

namespace monorail_android.Test.Scripts.Wishlist
{
    internal class WishlistOnboardingSuccessful : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+22.";
        private const string UsernameSuffix = "@gmail.com";

        [Test]
        public void WishlistOnboardingThroughFundYourWishlistButtonSuccessful()
        {
            var loginPage = new LoginPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var wishlistItemDetailsPage = new WishlistItemDetailsPage(Driver);
            var personalInformationPage = new PersonalInformationPage(Driver);
            var firstNameLastNamePage = new FirstNameLastNamePage(Driver);
            var ssnPage = new SsnPage(Driver);
            var residentialAddressPage = new ResidentialAddressPage(Driver);
            var politicalExposureQuestionPage = new PoliticalExposureQuestionPage(Driver);
            var linkAnAccountPage = new LinkAnAccountPage(Driver);
            var electronicDeliveryConsentPage = new ElectronicDeliveryConsentPage(Driver);
            var termsAndConditionsPage = new TermsAndConditionsPage(Driver);
            var wishlistAddCashPage = new WishlistAddCashPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            RegisterUser(username);
            AddPersonalizedWishlistItem(username, WishlistItemUrl, WishlistItemName,
                WishlistItemDescription, WishlistItemPrice, WishlistItemImage, WishlistItemFavicon);

            GoThroughLaunchScreens();

            Thread.Sleep(20000); // wait for Wishlist Item to be correctly added

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainWishlistPage
                .ClickWishlistItem(WishlistItemName);

            wishlistItemDetailsPage
                .WaitUntilWishlistItemDetailsPageForNotReadyToBuyStateIsLoaded()
                .ClickFundYourWishlistButton();

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

            wishlistAddCashPage
                .WaitUntilWishlistAddCashPageIsLoaded()
                .ClickBackButton();

            wishlistItemDetailsPage
                .WaitUntilWishlistItemDetailsPageForNotReadyToBuyStateIsLoaded()
                .ClickBackButton();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }
    }
}