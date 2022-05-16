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
    public class LaunchWishlistPage
    {
        private const string LaunchWishlistScreenHeaderText = "WISHLIST";
        private const string LaunchWishlistMessageHeaderTextPartOne = "Put everything you";
        private const string LaunchWishlistMessageHeaderTextPartTwo = "want in one place.";
        private const string LaunchWishlistMessageTextPartOne = "Make your life and shopping easier by";
        private const string LaunchWishlistMessageTextPartTwo = "having a single wishlist. So you know what";
        private const string LaunchWishlistMessageTextPartThree = "items are first priority.";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup/android.widget.TextView[3]")]
        private IWebElement _launchWishlistMessage;

        [FindsBy(How = How.Id, Using = "labelTitle")]
        private IWebElement _launchWishlistMessageHeader;

        [FindsBy(How = How.Id, Using = "labelCategory")]
        private IWebElement _launchWishlistScreenHeader;

        public LaunchWishlistPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public LaunchWishlistPage ClickContinueButton()
        {
            WaitUntilLaunchWishlistPageIsLoaded();
            _continueButton.Click();
            return this;
        }

        private void WaitUntilLaunchWishlistPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_launchWishlistScreenHeader));
                    Wait.Until(ElementToBeVisible(_launchWishlistMessageHeader));
                    Wait.Until(ElementToBeVisible(_launchWishlistMessage));
                    Wait.Until(ElementToBeClickable(_continueButton));

                    _launchWishlistScreenHeader.Text.Should().Contain(LaunchWishlistScreenHeaderText);
                    _launchWishlistMessageHeader.Text.Should().Contain(LaunchWishlistMessageHeaderTextPartOne);
                    _launchWishlistMessageHeader.Text.Should().Contain(LaunchWishlistMessageHeaderTextPartTwo);
                    _launchWishlistMessage.Text.Should().Contain(LaunchWishlistMessageTextPartOne);
                    _launchWishlistMessage.Text.Should().Contain(LaunchWishlistMessageTextPartTwo);
                    _launchWishlistMessage.Text.Should().Contain(LaunchWishlistMessageTextPartThree);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}