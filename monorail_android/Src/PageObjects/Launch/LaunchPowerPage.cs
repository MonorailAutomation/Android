using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Launch
{
    public class LaunchPowerPage
    {
        private const string LaunchPowerScreenHeaderText = "POWER";
        private const string LaunchPowerMessageHeaderText = "Save on autopilot.";
        private const string LaunchPowerMessageTextPartOne = "Connect your bank account to tuck away";
        private const string LaunchPowerMessageTextPartTwo = "savings on autopilot. And grow that";
        private const string LaunchPowerMessageTextPartThree = "Wishlist Fund. So you’ll be ready to buy";
        private const string LaunchPowerMessageTextPartFour = "your items in no time.";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup/android.widget.TextView[3]")]
        private IWebElement _launchPowerMessage;

        [FindsBy(How = How.Id, Using = "labelTitle")]
        private IWebElement _launchPowerMessageHeader;

        [FindsBy(How = How.Id, Using = "labelCategory")]
        private IWebElement _launchPowerScreenHeader;

        public LaunchPowerPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public LaunchPowerPage ClickContinueButton()
        {
            WaitUntilLaunchPowerPageIsLoaded();
            _continueButton.Click();
            return this;
        }

        private void WaitUntilLaunchPowerPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_launchPowerScreenHeader));
                    Wait.Until(ElementToBeVisible(_launchPowerMessageHeader));
                    Wait.Until(ElementToBeVisible(_launchPowerMessage));
                    Wait.Until(ElementToBeClickable(_continueButton));

                    _launchPowerScreenHeader.Text.Should().Contain(LaunchPowerScreenHeaderText);
                    _launchPowerMessageHeader.Text.Should().Contain(LaunchPowerMessageHeaderText);
                    _launchPowerMessage.Text.Should().Contain(LaunchPowerMessageTextPartOne);
                    _launchPowerMessage.Text.Should().Contain(LaunchPowerMessageTextPartTwo);
                    _launchPowerMessage.Text.Should().Contain(LaunchPowerMessageTextPartThree);
                    _launchPowerMessage.Text.Should().Contain(LaunchPowerMessageTextPartFour);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}