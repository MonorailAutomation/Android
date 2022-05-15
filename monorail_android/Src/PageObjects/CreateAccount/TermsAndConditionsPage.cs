using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.CreateAccount
{
    public class TermsAndConditionsPage
    {
        private const string TermsAndConditionsHeaderText = "Terms and Conditions";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _agreeAndFinishButton;

        [FindsBy(How = How.Id, Using = "scrollToBottom")]
        private IWebElement _skipToBottomButton;

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _termsAndConditionsHeader;

        public TermsAndConditionsPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Agree and Finish' button")]
        public TermsAndConditionsPage ClickAgreeAndFinishButton()
        {
            while (_agreeAndFinishButton.Enabled == false) Wait.Until(ElementToBeClickable(_agreeAndFinishButton));
            _agreeAndFinishButton.Click();
            return this;
        }

        [AllureStep("Click 'Skip to Bottom' button")]
        public TermsAndConditionsPage ClickSkipToBottomButton()
        {
            WaitUntilTermsAndConditionsPageIsLoaded();
            _skipToBottomButton.Click();
            return this;
        }

        private void WaitUntilTermsAndConditionsPageIsLoaded()
        {
            Wait.Until(ElementToBeVisible(_termsAndConditionsHeader));
            Wait.Until(ElementToBeVisible(_skipToBottomButton));
            Wait.Until(ElementToBeVisible(_agreeAndFinishButton));

            _termsAndConditionsHeader.Text.Should().Be(TermsAndConditionsHeaderText);
        }
    }
}