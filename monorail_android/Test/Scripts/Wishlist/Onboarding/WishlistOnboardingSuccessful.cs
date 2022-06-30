using monorail_android.PageObjects;
using monorail_android.PageObjects.Commons.Onboarding;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Wishlist;
using monorail_android.PageObjects.Invest;
using monorail_android.PageObjects.Wishlist.ItemPages;
using monorail_android.PageObjects.Wishlist.TransactionPages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Helpers.UserOnboardingHelperFunctions;
using static monorail_android.Test.Scripts.Transactions.Plaid.ConnectPlaidToNewUser;
using static monorail_android.RestRequests.Helpers.WishlistHelperFunctions;
using static monorail_android.RestRequests.Endpoints.Management.PilotFeatures;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.DataGenerators.EmailGenerator;
using static monorail_android.RestRequests.Helpers.UserManagementHelperFunctions;

namespace monorail_android.Test.Scripts.Wishlist.Onboarding
{
    [TestFixture]
    [AllureNUnit]
    internal class WishlistOnboardingSuccessful : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+22.";
        private const string UsernameSuffix = "@gmail.com";

        [Test(Description =
            "Wishlist Onboarding - Successful - through Wishlist Item Details screen by clicking 'Fund your Wishlist' button")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Onboarding")]
        [AllureStory(
            "Wishlist Onboarding - Successful - through Wishlist Item Details screen by clicking 'Fund your Wishlist' button")]
        public void WishlistOnboardingThroughFundYourWishlistButtonSuccessful()
        {
            var loginPage = new LoginPage(Driver);
            var emptyMilestonesPage = new EmptyMilestonesPage(Driver);
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
            AddUserToPilot(username, "useWishlist");
            AddPersonalizedWishlistItem(username, WishlistItemUrl, WishlistItemName, WishlistItemDescription,
                WishlistItemPrice, WishlistItemImage, WishlistItemFavicon);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            emptyMilestonesPage
                .WaitUntilEmptyMilestonesPageIsLoaded();

            mainMenuPage
                .ClickSideMenu()
                .ClickWishlist();

            mainWishlistPage
                .CheckIfWishlistItemIsDisplayedOnMainScreen(WishlistItemName)
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

            mainWishlistPage
                .WaitUntilMainWishlistPageIsLoaded()
                .ClickBackButton();

            mainMenuPage
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();

            CloseUser(username);
        }
    }
}