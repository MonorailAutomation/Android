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
    public class LaunchBuyPage
    {
        private const string LaunchBuyScreenHeaderText = "BUY";
        private const string LaunchBuyMessageHeaderTextPartOne = "Get the stuff";
        private const string LaunchBuyMessageHeaderTextPartTwo = "you really want.";
        private const string LaunchBuyMessageTextPartOne = "As your Wishlist Fund grows, your items will";
        private const string LaunchBuyMessageTextPartTwo = "get the green light. Now just choose what";
        private const string LaunchBuyMessageTextPartThree = "you want to buy!";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _getStartedButton;

        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup/android.widget.TextView[3]")]
        private IWebElement _launchBuyMessage;

        [FindsBy(How = How.Id, Using = "labelTitle")]
        private IWebElement _launchBuyMessageHeader;

        [FindsBy(How = How.Id, Using = "labelCategory")]
        private IWebElement _launchBuyScreenHeader;

        public LaunchBuyPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Get Started' button")]
        public LaunchBuyPage ClickGetStartedButton()
        {
            WaitUntilLaunchBuyPageIsLoaded();
            _getStartedButton.Click();
            return this;
        }

        private void WaitUntilLaunchBuyPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_launchBuyScreenHeader));
                    Wait.Until(ElementToBeVisible(_launchBuyMessageHeader));
                    Wait.Until(ElementToBeVisible(_launchBuyMessage));
                    Wait.Until(ElementToBeClickable(_getStartedButton));

                    _launchBuyScreenHeader.Text.Should().Contain(LaunchBuyScreenHeaderText);
                    _launchBuyMessageHeader.Text.Should().Contain(LaunchBuyMessageHeaderTextPartOne);
                    _launchBuyMessageHeader.Text.Should().Contain(LaunchBuyMessageHeaderTextPartTwo);
                    _launchBuyMessage.Text.Should().Contain(LaunchBuyMessageTextPartOne);
                    _launchBuyMessage.Text.Should().Contain(LaunchBuyMessageTextPartTwo);
                    _launchBuyMessage.Text.Should().Contain(LaunchBuyMessageTextPartThree);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}