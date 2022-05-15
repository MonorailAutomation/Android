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
    public class ItemIsBeingAddedPage
    {
        private const string ItemIsBeingAddedMessageHeaderText = "Your new item is being added!";

        private const string ItemIsBeingAddedMessageText =
            "This process can take a few seconds, feel free to close this screen in the meantime.";

        [FindsBy(How = How.Id, Using = "buttonClose")]
        private IWebElement _closeButton;

        [FindsBy(How = How.Id, Using = "labelSubtitle")]
        private IWebElement _itemIsBeingAddedMessage;

        [FindsBy(How = How.Id, Using = "labelTitle")]
        private IWebElement _itemIsBeingAddedMessageHeader;

        public ItemIsBeingAddedPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public ItemIsBeingAddedPage ClickCloseButton()
        {
            WaitUntilItemIsBeingAddedPageIsLoaded();
            _closeButton.Click();
            return this;
        }

        private void WaitUntilItemIsBeingAddedPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_itemIsBeingAddedMessageHeader));
                    Wait.Until(ElementToBeVisible(_itemIsBeingAddedMessage));
                    Wait.Until(ElementToBeVisible(_closeButton));

                    _itemIsBeingAddedMessageHeader.Text.Should().Contain(ItemIsBeingAddedMessageHeaderText);
                    _itemIsBeingAddedMessage.Text.Should().Contain(ItemIsBeingAddedMessageText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}