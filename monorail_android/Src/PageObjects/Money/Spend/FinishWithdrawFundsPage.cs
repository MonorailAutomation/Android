using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.Money.Spend
{
    public class FinishWithdrawFundsPage
    {
        private const string TransferringMessageText = "Transferring";
        private const string FundsOnTheWayMessageTextPartOne = "Funds are on their way to your";
        private const string FundsOnTheWayMessageTextPartTwo = "connected account!";

        [FindsBy(How = How.Id, Using = "labelTransferringOnTheWay")]
        private IWebElement _fundsOnTheWayMessage;

        [FindsBy(How = How.Id, Using = "buttonReturn")]
        private IWebElement _returnButton;

        [FindsBy(How = How.Id, Using = "labelTransferring")]
        private IWebElement _transferringMessage;

        public FinishWithdrawFundsPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public FinishWithdrawFundsPage ClickReturnButton()
        {
            WaitUntilTrackWithdrawCashFinishPageIsLoaded();
            _returnButton.Click();
            return this;
        }

        private void WaitUntilTrackWithdrawCashFinishPageIsLoaded()
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
                    _fundsOnTheWayMessage.Text.Should().Contain(FundsOnTheWayMessageTextPartOne);
                    _fundsOnTheWayMessage.Text.Should().Contain(FundsOnTheWayMessageTextPartTwo);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}