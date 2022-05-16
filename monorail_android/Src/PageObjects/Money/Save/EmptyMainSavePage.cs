using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.Money.Save
{
    public class EmptyMainSavePage
    {
        private const string EmptyScreenFirstBulletPointText = "Create your emergency fund";
        private const string EmptyScreenSecondBulletPointText = "Budget your monthly expenses";
        private const string EmptyScreenThirdBulletPointText = "Power your personal goals";
        private const string EmptyScreenFourthBulletPointText = "Save for $$$ items";

        private const string EmptyScreenMessageHeaderText = "Separate your Wishlist from your dedicated savings funds.";

        private const string EmptyScreenMessageText =
            "And automate deposits on your schedule. So you always stay… on Track. Whether you feel motivated or not.";

        [FindsBy(How = How.Id, Using = "text1")]
        private IWebElement _emptyScreenFirstBulletPoint;

        [FindsBy(How = How.Id, Using = "text4")]
        private IWebElement _emptyScreenFourthBulletPoint;

        [FindsBy(How = How.Id, Using = "labelText")]
        private IWebElement _emptyScreenMessage;

        [FindsBy(How = How.XPath, Using = "//android.widget.ScrollView//android.widget.TextView[1]")]
        private IWebElement _emptyScreenMessageHeader;

        [FindsBy(How = How.Id, Using = "text2")]
        private IWebElement _emptyScreenSecondBulletPoint;

        [FindsBy(How = How.Id, Using = "text3")]
        private IWebElement _emptyScreenThirdBulletPoint;

        [FindsBy(How = How.Id, Using = "buttonOpenCheckingAccount")]
        private IWebElement _unlockSavingsTracksButton;

        public EmptyMainSavePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Unlock Savings Tracks' button")]
        public EmptyMainSavePage ClickUnlockSavingsTracks()
        {
            WaitUntilEmptySavePageIsLoaded();
            _unlockSavingsTracksButton.Click();
            return this;
        }

        private void WaitUntilEmptySavePageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_emptyScreenMessageHeader));
                    Wait.Until(ElementToBeVisible(_emptyScreenFirstBulletPoint));
                    Wait.Until(ElementToBeVisible(_emptyScreenSecondBulletPoint));
                    Wait.Until(ElementToBeVisible(_emptyScreenThirdBulletPoint));
                    Wait.Until(ElementToBeVisible(_emptyScreenFourthBulletPoint));
                    Wait.Until(ElementToBeClickable(_unlockSavingsTracksButton));

                    _emptyScreenMessageHeader.Text.Should().Contain(EmptyScreenMessageHeaderText);
                    _emptyScreenMessage.Text.Should().Contain(EmptyScreenMessageText);
                    _emptyScreenFirstBulletPoint.Text.Should().Contain(EmptyScreenFirstBulletPointText);
                    _emptyScreenSecondBulletPoint.Text.Should().Contain(EmptyScreenSecondBulletPointText);
                    _emptyScreenThirdBulletPoint.Text.Should().Contain(EmptyScreenThirdBulletPointText);
                    _emptyScreenFourthBulletPoint.Text.Should().Contain(EmptyScreenFourthBulletPointText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}