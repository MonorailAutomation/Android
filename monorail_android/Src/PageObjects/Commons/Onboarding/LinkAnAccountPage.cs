using System;
using FluentAssertions;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

namespace monorail_android.PageObjects.Commons.Onboarding
{
    public class LinkAnAccountPage
    {
        private const string InformationMessageText =
            "End to end encryption. Your credentials are never made available to Monorail.";

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[2]")]
        private IWebElement _informationMessage;

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _linkYourAccountButton;

        [FindsBy(How = How.Id, Using = "progressIndicator")]
        private IWebElement _progressIndicator;

        public LinkAnAccountPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public LinkAnAccountPage ClickLinkYourAccountButton()
        {
            WaitUntilLinkAnAccountPageIsLoaded();
            _linkYourAccountButton.Click();
            return this;
        }

        private void WaitUntilLinkAnAccountPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Waits.ElementToBeNotVisible(_progressIndicator);
                    Waits.ElementToBeVisible(_informationMessage);
                    Waits.ElementToBeClickable(_linkYourAccountButton);

                    _informationMessage.Text.Should().Contain(InformationMessageText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}