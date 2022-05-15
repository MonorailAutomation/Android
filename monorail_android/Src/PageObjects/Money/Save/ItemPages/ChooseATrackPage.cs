using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.Money.Save.ItemPages
{
    public class ChooseATrackPage
    {
        private const string ChooseATrackPageTitleText = "Choose a Track";

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _pageTitle;

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[contains(@text, 'Travel')]")]
        private IWebElement _travelTrack;

        public ChooseATrackPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Travel' track")]
        public ChooseATrackPage ClickTravelTrack()
        {
            WaitUntilChooseATrackPageIsLoaded();
            _travelTrack.Click();
            return this;
        }

        private void WaitUntilChooseATrackPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_pageTitle));
                    Wait.Until(ElementToBeVisible(_travelTrack));

                    _pageTitle.Text.Should().Contain(ChooseATrackPageTitleText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}