using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.Money.Save
{
    public class TrackDetailsPage
    {
        private const string TrackBadgeText = "Track";

        [FindsBy(How = How.Id, Using = "buttonDeposit")]
        private IWebElement _addFundsButton;

        [FindsBy(How = How.Id, Using = "backButton")]
        private IWebElement _backButton;

        [FindsBy(How = How.Id, Using = "goalTypeIndicator")]
        private IWebElement _trackBadge;

        [FindsBy(How = How.Id, Using = "trackImage")]
        private IWebElement _trackImage;

        [FindsBy(How = How.Id, Using = "buttonWithdraw")]
        private IWebElement _withdrawButton;

        public TrackDetailsPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public TrackDetailsPage ClickWithdrawButton()
        {
            WaitUntilTrackDetailsPageIsLoaded();
            _withdrawButton.Click();
            return this;
        }

        public TrackDetailsPage ClickBackButton()
        {
            WaitUntilTrackDetailsPageIsLoaded();
            _backButton.Click();
            return this;
        }

        private void WaitUntilTrackDetailsPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_backButton));
                    Wait.Until(ElementToBeVisible(_trackBadge));
                    Wait.Until(ElementToBeVisible(_trackImage));
                    Wait.Until(ElementToBeVisible(_withdrawButton));
                    Wait.Until(ElementToBeVisible(_addFundsButton));

                    _trackBadge.Text.Should().Contain(TrackBadgeText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}