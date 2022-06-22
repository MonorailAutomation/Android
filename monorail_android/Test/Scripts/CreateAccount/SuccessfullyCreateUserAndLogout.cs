using System.Threading;
using monorail_android.PageObjects;
using monorail_android.PageObjects.CreateAccount;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Invest;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.Database.VerificationCode;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.DataGenerators.EmailGenerator;
using static monorail_android.RestRequests.Helpers.UserManagementHelperFunctions;

namespace monorail_android.Test.Scripts.CreateAccount
{
    [TestFixture]
    [AllureNUnit]
    public class SuccessfullyCreateUserAndLogout : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+20.";
        private const string UsernameSuffix = "@gmail.com";

        [Test(Description = "Create user with text message verification")]
        [AllureEpic("Create user")]
        [AllureFeature("Successfully create user")]
        [AllureStory("Create user with text message verification")]
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
            var emptyTradingPage = new EmptyTradingPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

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

            emptyTradingPage
                .WaitUntilEmptyTradingPageIsLoaded();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();

            CloseUser(username);
        }

        [Test(Description = "Create user with email message verification")]
        [AllureEpic("Create user")]
        [AllureFeature("Successfully create user")]
        [AllureStory("Create user with email message verification")]
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
            var emptyTradingPage = new EmptyTradingPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

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

            emptyTradingPage
                .WaitUntilEmptyTradingPageIsLoaded();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();

            CloseUser(username);
        }
    }
}