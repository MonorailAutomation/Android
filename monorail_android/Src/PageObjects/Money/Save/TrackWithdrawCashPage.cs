using System;
using FluentAssertions;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.Money.Save
{
    public class TrackWithdrawCashPage
    {
        private const string WithdrawFundsPageTitleText = "Withdraw Funds";
        private const string ChooseAWithdrawalAmountMessageText = "Choose a withdrawal amount";

        [FindsBy(How = How.Id, Using = "labelChoose")]
        private IWebElement _chooseAWithdrawalAmountMessage;

        [FindsBy(How = How.Id, Using = "buttonConfirm")]
        private IWebElement _confirmButton;

        [FindsBy(How = How.Id, Using = "labelScreenTitle")]
        private IWebElement _withdrawFundsPageTitle;

        public TrackWithdrawCashPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public TrackWithdrawCashPage ClickConfirmButton()
        {
            while (_confirmButton.Enabled == false) ElementToBeClickable(_confirmButton);
            _confirmButton.Click();
            return this;
        }

        public TrackWithdrawCashPage SetAmount(string amount)
        {
            WaitUntilTrackWithdrawCashPageIsLoaded();
            CustomKeyboard.SendKeys(amount);
            return this;
        }

        private void WaitUntilTrackWithdrawCashPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_withdrawFundsPageTitle));
                    Wait.Until(ElementToBeVisible(_chooseAWithdrawalAmountMessage));
                    Wait.Until(ElementToBeVisible(_confirmButton));

                    _withdrawFundsPageTitle.Text.Should().Contain(WithdrawFundsPageTitleText);
                    _chooseAWithdrawalAmountMessage.Text.Should().Contain(ChooseAWithdrawalAmountMessageText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}