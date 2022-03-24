using System;
using FluentAssertions;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

namespace monorail_android.PageObjects.Money.Spend
{
    public class MainSpendPage
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

        [FindsBy(How = How.Id, Using = "progressIndicator")]
        private IWebElement _progressIndicator;

        public MainSpendPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public MainSpendPage ClickOpenYourCheckingAccountButton()
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
                    Waits.ElementToBeNotVisible(_progressIndicator);
                    Waits.ElementToBeVisible(_openCheckingAccountSection);
                    Waits.ElementToBeVisible(_emptyScreenMessageHeader);
                    Waits.ElementToBeVisible(_emptyScreenFirstBulletPoint);
                    Waits.ElementToBeVisible(_emptyScreenSecondBulletPoint);
                    Waits.ElementToBeVisible(_emptyScreenThirdBulletPoint);
                    Waits.ElementToBeVisible(_emptyScreenFourthBulletPoint);
                    Waits.ElementToBeClickable(_openYourCheckingAccountButton);

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