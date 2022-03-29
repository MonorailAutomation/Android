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
    public class MainSavePage
    {
        private const string SelectYourTracksHeaderText = "Select Your Tracks";

        private const string InformationMessageText =
            "Choose some saving tracks to start with. You can add, remove, or customize these anytime.";

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

        [FindsBy(How = How.Id, Using = "buttonGetStarted")]
        private IWebElement _getStartedButton;

        [FindsBy(How = How.Id, Using = "buttonHowItWorks")]
        private IWebElement _howItWorksButton;

        [FindsBy(How = How.Id, Using = "labelDescription")]
        private IWebElement _informationMessage;

        [FindsBy(How = How.Id, Using = "progressIndicator")]
        private IWebElement _progressIndicator;

        [FindsBy(How = How.Id, Using = "labelSelect")]
        private IWebElement _selectYourTracksHeader;

        [FindsBy(How = How.Id, Using = "mainScrollLayout")]
        private IWebElement _selectYourTracksScrollView;

        [FindsBy(How = How.Id, Using = "buttonOpenCheckingAccount")]
        private IWebElement _unlockSavingsTracksButton;

        public MainSavePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public MainSavePage ClickUnlockSavingsTracks()
        {
            WaitUntilEmptySavePageIsLoaded();
            _unlockSavingsTracksButton.Click();
            return this;
        }

        public MainSavePage ClickTrack(string trackName)
        {
            WaitUntilSavePageAfterOnboardingIsLoaded();
            var track = Driver.FindElementByXPath("//*[contains(@text, '" + trackName + "')]");
            track.Click();
            return this;
        }

        public MainSavePage ClickGetStartedButton()
        {
            Wait.Until(ElementToBeVisible(_selectYourTracksScrollView));

            var firstPointX = _selectYourTracksScrollView.Size.Width / 2;
            var firstPointY = _selectYourTracksScrollView.Location.Y + 10;

            var secondPointX = _selectYourTracksScrollView.Size.Width / 2;
            var secondPointY = _selectYourTracksScrollView.Location.Y +
                _selectYourTracksScrollView.Size.Height - 300;

            Scroll.ScrollFromToCoordinates(firstPointX, firstPointY, secondPointX, secondPointY);

            while (_getStartedButton.Enabled == false) Wait.Until(ElementToBeClickable(_getStartedButton));

            _getStartedButton.Click();
            return this;
        }

        private void WaitUntilSavePageAfterOnboardingIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeNotVisible(_progressIndicator));
                    Wait.Until(ElementToBeVisible(_selectYourTracksHeader));
                    Wait.Until(ElementToBeVisible(_informationMessage));
                    Wait.Until(ElementToBeClickable(_howItWorksButton));

                    _selectYourTracksHeader.Text.Should().Contain(SelectYourTracksHeaderText);
                    _informationMessage.Text.Should().Contain(InformationMessageText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }

        private void WaitUntilEmptySavePageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeNotVisible(_progressIndicator));
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