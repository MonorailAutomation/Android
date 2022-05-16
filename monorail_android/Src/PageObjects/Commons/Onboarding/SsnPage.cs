using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Commons.Onboarding
{
    public class SsnPage
    {
        private const string YourSsnLabelText = "Your SSN";

        private const string InformationMessageTextPartOne =
            "This is required to move money with Vimvest.";

        private const string InformationMessageTextPartTwo =
            "Your information is encrypted.";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "labelBottomHint")]
        private IWebElement _informationMessage;

        [FindsBy(How = How.Id, Using = "editField")]
        private IWebElement _ssnInput;

        [FindsBy(How = How.Id, Using = "labelFirstName")]
        private IWebElement _yourSsnLabel;

        public SsnPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Pass SSN: '{0}'")]
        public SsnPage PassSsn(string ssn)
        {
            WaitUntilSsnPageIsLoaded();
            _ssnInput.SendKeys(ssn);
            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public SsnPage ClickContinueButton()
        {
            while (_continueButton.Enabled == false) ElementToBeClickable(_continueButton);
            _continueButton.Click();
            return this;
        }

        private void WaitUntilSsnPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_yourSsnLabel));
                    Wait.Until(ElementToBeVisible(_ssnInput));
                    Wait.Until(ElementToBeVisible(_continueButton));

                    _yourSsnLabel.Text.Should().Contain(YourSsnLabelText);
                    _informationMessage.Text.Should().Contain(InformationMessageTextPartOne);
                    _informationMessage.Text.Should().Contain(InformationMessageTextPartTwo);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}