using System.Threading;
using monorail_android.PageObjects;
using monorail_android.PageObjects.CreateAccount;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Wishlist;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.Commons.RandomGenerator;
using static monorail_android.Database.VerificationCode;

namespace monorail_android.Test.Scripts.CreateAccount
{
    [TestFixture]
    public class SuccessfullyCreateUserAndLogout : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+20.020522";
        private const string UsernameSuffix = "@gmail.com";

        [Test]
        public void CreateUserWithTextMessageVerificationTest()
        {
            var loginPage = new LoginPage(Driver);
            var gettingStartedEmailPage = new GettingStartedEmailPage(Driver);
            var gettingStartedPasswordPage = new GettingStartedPasswordPage(Driver);
            var gettingStartedDobPage = new GettingStartedDobPage(Driver);
            var gettingStartedPhoneNumberPage = new GettingStartedPhoneNumberPage(Driver);
            var verifyYourAccountMethodPage = new VerifyYourAccountMethodPage(Driver);
            var verifyYourAccountVerificationCodePage = new VerifyYourAccountVerificationCodePage(Driver);
            var termsAndConditionsPage = new TermsAndConditionsPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            loginPage
                .ClickCreateAnAccountButton();

            gettingStartedEmailPage
                .PassEmail(username)
                .ClickContinueButton();

            gettingStartedPasswordPage
                .PassPassword(ValidPassword)
                .ClickContinueButton();

            gettingStartedDobPage
                .SetMonth("Jan")
                .SetDay("01")
                .SetYear("1991")
                .ClickContinueButton();

            gettingStartedPhoneNumberPage
                .PassPhoneNumber("9419252125")
                .ClickContinueButton();

            verifyYourAccountMethodPage
                .ClickTextMessageOption()
                .ClickContinue();

            Thread.Sleep(5500); // waiting for results in DB

            verifyYourAccountVerificationCodePage
                .PassVerificationCode(GetVerificationCode(username))
                .ClickContinueButton();

            termsAndConditionsPage
                .ClickSkipToBottomButton()
                .ClickAgreeAndFinishButton();

            mainWishlistPage
                .WaitUntilEmptyMainWishlistPageIsLoaded();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }
        
        [Test]
        public void CreateUserWithEmailMessageVerificationTest()
        {
            var loginPage = new LoginPage(Driver);
            var gettingStartedEmailPage = new GettingStartedEmailPage(Driver);
            var gettingStartedPasswordPage = new GettingStartedPasswordPage(Driver);
            var gettingStartedDobPage = new GettingStartedDobPage(Driver);
            var gettingStartedPhoneNumberPage = new GettingStartedPhoneNumberPage(Driver);
            var verifyYourAccountMethodPage = new VerifyYourAccountMethodPage(Driver);
            var verifyYourAccountVerificationCodePage = new VerifyYourAccountVerificationCodePage(Driver);
            var termsAndConditionsPage = new TermsAndConditionsPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            loginPage
                .ClickCreateAnAccountButton();

            gettingStartedEmailPage
                .PassEmail(username)
                .ClickContinueButton();

            gettingStartedPasswordPage
                .PassPassword(ValidPassword)
                .ClickContinueButton();

            gettingStartedDobPage
                .SetMonth("Jan")
                .SetDay("01")
                .SetYear("1991")
                .ClickContinueButton();

            gettingStartedPhoneNumberPage
                .PassPhoneNumber("9419252125")
                .ClickContinueButton();

            verifyYourAccountMethodPage
                .ClickEmailOption()
                .ClickContinue();

            Thread.Sleep(5500); // waiting for results in DB

            verifyYourAccountVerificationCodePage
                .PassVerificationCode(GetVerificationCode(username))
                .ClickContinueButton();

            termsAndConditionsPage
                .ClickSkipToBottomButton()
                .ClickAgreeAndFinishButton();

            mainWishlistPage
                .WaitUntilEmptyMainWishlistPageIsLoaded();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }
    }
}