using System;
using FluentAssertions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Money.Spend
{
    public class EmptyMainSpendPage
    {
        private const string EmptyScreenMessageHeaderText =
            "Spend your money directly from Monorail using the free checking account and debit card.";

        private const string EmptyScreenFirstBulletPointText =
            "Stay on top of every purchase with transparent transactions";

        private const string EmptyScreenSecondBulletPointText = "Balance work and life by enabling direct deposit";
        private const string EmptyScreenThirdBulletPointText = "Only spend what you have with the Monorail debit card";
        private const string EmptyScreenFourthBulletPointText = "Keep your money all in one place";

        [FindsBy(How = How.Id, Using = "text1")]
        private IWebElement _emptyScreenFirstBulletPoint;

        [FindsBy(How = How.Id, Using = "text4")]
        private IWebElement _emptyScreenFourthBulletPoint;

        [FindsBy(How = How.XPath, Using = "//android.widget.ScrollView//android.widget.TextView[1]")]
        private IWebElement _emptyScreenMessageHeader;

        [FindsBy(How = How.Id, Using = "text2")]
        private IWebElement _emptyScreenSecondBulletPoint;

        [FindsBy(How = How.Id, Using = "text3")]
        private IWebElement _emptyScreenThirdBulletPoint;

        [FindsBy(How = How.Id, Using = "openCheckingAccountSection")]
        private IWebElement _openCheckingAccountSection;

        [FindsBy(How = How.Id, Using = "buttonOpenCheckingAccount")]
        private IWebElement _openYourCheckingAccountButton;

        public EmptyMainSpendPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Open your Checking Account' button")]
        public EmptyMainSpendPage ClickOpenYourCheckingAccountButton()
        {
            WaitUntilEmptySpendPageIsLoaded();
            _openYourCheckingAccountButton.Click();
            return this;
        }

        private void WaitUntilEmptySpendPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_openCheckingAccountSection));
                    Wait.Until(ElementToBeVisible(_emptyScreenMessageHeader));
                    Wait.Until(ElementToBeVisible(_emptyScreenFirstBulletPoint));
                    Wait.Until(ElementToBeVisible(_emptyScreenSecondBulletPoint));
                    Wait.Until(ElementToBeVisible(_emptyScreenThirdBulletPoint));
                    Wait.Until(ElementToBeVisible(_emptyScreenFourthBulletPoint));
                    Wait.Until(ElementToBeClickable(_openYourCheckingAccountButton));

                    _emptyScreenMessageHeader.Text.Should().Contain(EmptyScreenMessageHeaderText);
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