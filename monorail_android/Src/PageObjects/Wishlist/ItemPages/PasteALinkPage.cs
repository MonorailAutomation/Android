using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist.ItemPages
{
    public class PasteALinkPage
    {
        private const string PasteALinkLabelText = "Paste a link from anywhere on the web:";

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "buttonSave")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "labelPaste")]
        private IWebElement _pasteALinkLabel;

        [FindsBy(How = How.Id, Using = "textLink")]
        private IWebElement _urlInput;

        public PasteALinkPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public PasteALinkPage ClickContinueButton()
        {
            while (_continueButton.Enabled == false) Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }

        [AllureStep("Paste URL: '{0}'")]
        public PasteALinkPage PasteUrl(string wishlistItemUrl)
        {
            WaitUntilPasteALinkPageIsLoaded();
            _urlInput.SendKeys(wishlistItemUrl);
            return this;
        }

        private void WaitUntilPasteALinkPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_pasteALinkLabel));
                    Wait.Until(ElementToBeVisible(_urlInput));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_continueButton));

                    _pasteALinkLabel.Text.Should().Contain(PasteALinkLabelText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}