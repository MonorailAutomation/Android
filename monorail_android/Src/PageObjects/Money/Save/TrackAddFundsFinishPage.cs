using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.Money.Save
{
    public class TrackAddFundsFinishPage
    {
        private const string TransferringMessageText = "Transferring";
        private const string FundsOnTheWayMessageText = "Funds are on their way to Monorail!";

        [FindsBy(How = How.Id, Using = "labelTransferringOnTheWay")]
        private IWebElement _fundsOnTheWayMessage;

        [FindsBy(How = How.Id, Using = "buttonReturn")]
        private IWebElement _returnButton;

        [FindsBy(How = How.Id, Using = "labelTransferring")]
        private IWebElement _transferringMessage;

        public TrackAddFundsFinishPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public TrackAddFundsFinishPage ClickReturnButton()
        {
            WaitUntilTrackAddFundsFinishPageIsLoaded();
            _returnButton.Click();
            return this;
        }

        private void WaitUntilTrackAddFundsFinishPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_transferringMessage));
                    Wait.Until(ElementToBeVisible(_fundsOnTheWayMessage));
                    Wait.Until(ElementToBeVisible(_returnButton));

                    _transferringMessage.Text.Should().Contain(TransferringMessageText);
                    _fundsOnTheWayMessage.Text.Should().Contain(FundsOnTheWayMessageText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}