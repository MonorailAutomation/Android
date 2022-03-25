using System;
using FluentAssertions;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

namespace monorail_android.PageObjects.Commons.Onboarding
{
    public class SsnPage
    {
        private const string YourSsnLabelText = "Your SSN";

        private const string InformationMessageText =
            "This is required to move money with Vimvest. Your information is encrypted.";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "labelBottomHint")]
        private IWebElement _informationMessage;

        [FindsBy(How = How.Id, Using = "progressIndicator")]
        private IWebElement _progressIndicator;

        [FindsBy(How = How.Id, Using = "editField")]
        private IWebElement _ssnInput;

        [FindsBy(How = How.Id, Using = "labelFirstName")]
        private IWebElement _yourSsnLabel;

        public SsnPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public SsnPage PassSsn(string ssn)
        {
            WaitUntilSsnPageIsLoaded();
            _ssnInput.SendKeys(ssn);
            return this;
        }

        public SsnPage ClickContinueButton()
        {
            while (_continueButton.Enabled == false) Waits.ElementToBeClickable(_continueButton);
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
                    Waits.ElementToBeNotVisible(_progressIndicator);
                    Waits.ElementToBeVisible(_yourSsnLabel);
                    Waits.ElementToBeVisible(_ssnInput);
                    Waits.ElementToBeClickable(_continueButton);

                    _yourSsnLabel.Text.Should().Contain(YourSsnLabelText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}