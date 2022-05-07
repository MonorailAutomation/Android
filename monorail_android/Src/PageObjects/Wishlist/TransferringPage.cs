using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist
{
    public class TransferringPage
    {
        private const string TransferringMessageText = "Transferring";

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _confirmButton;

        [FindsBy(How = How.Id, Using = "labelTransferring")]
        private IWebElement _transferringMessage;

        public TransferringPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public TransferringPage ClickConfirmButton()
        {
            WaitUntilTransferringPageIsLoaded();
            while (_confirmButton.Enabled == false) Wait.Until(ElementToBeClickable(_confirmButton));
            _confirmButton.Click();
            return this;
        }

        private void WaitUntilTransferringPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_transferringMessage));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_confirmButton));

                    _transferringMessage.Text.Should().Contain(TransferringMessageText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}