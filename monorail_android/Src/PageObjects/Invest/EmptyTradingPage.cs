using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Invest
{
    public class EmptyTradingPage
    {
        private const string EmptyScreenMessageHeaderText = "Invest";

        [FindsBy(How = How.Id, Using = "labelTitle")]
        private IWebElement _pageTitle;

        [FindsBy(How = How.Id, Using = "labelTrading")]
        private IWebElement _tradingTab;

        [FindsBy(How = How.Id, Using = "labelMilestones")]
        private IWebElement _milestonesTab;

        [FindsBy(How = How.Id, Using = "buttonHowItWorks")]
        private IWebElement _howItWorksButton;

        [FindsBy(How = How.Id, Using = "buttonStartTrading")]
        private IWebElement _startTradingButton;

        [FindsBy(How = How.Id, Using = "addPortfolio")]
        private IWebElement _addStockPlaceholder;

        public EmptyTradingPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Start Trading' button")]
        public EmptyTradingPage ClickStartTradingButton()
        {
            Wait.Until(ElementToBeVisible(_startTradingButton));
            _startTradingButton.Click();
            return this;
        }

        public EmptyTradingPage WaitUntilEmptyTradingPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeClickable(_howItWorksButton));
                    Wait.Until(ElementToBeClickable(_milestonesTab));
                    Wait.Until(ElementToBeClickable(_tradingTab));
                    Wait.Until(ElementToBeVisible(_pageTitle));
                    Wait.Until(ElementToBeVisible(_addStockPlaceholder));

                    _pageTitle.Text.Should().Contain(EmptyScreenMessageHeaderText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }

            return this;
        }
    }
}