using System;
using FluentAssertions;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

namespace monorail_android.PageObjects.Commons.Onboarding
{
    public class PoliticalExposureQuestionPage
    {
        private const string PoliticalExposureQuestionText =
            "Are you, or family, politically exposed or a public official?";

        private const string InformationMessageText =
            "Politically exposed means one who has been entrusted with a prominent public function.";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "labelBottomHint")]
        private IWebElement _informationMessage;

        [FindsBy(How = How.XPath, Using = "//*[contains(@text, 'Nope!')]")]
        private IWebElement _nopeAnswer;

        [FindsBy(How = How.Id, Using = "labelMainQuestion")]
        private IWebElement _politicalExposureQuestion;

        [FindsBy(How = How.Id, Using = "progressIndicator")]
        private IWebElement _progressIndicator;

        [FindsBy(How = How.XPath, Using = "//*[contains(@text, 'Yes.')]")]
        private IWebElement _yesAnswer;

        public PoliticalExposureQuestionPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public PoliticalExposureQuestionPage ClickNopeAnswer()
        {
            WaitUntilPoliticalExposureQuestionPageIsLoaded();
            _nopeAnswer.Click();
            return this;
        }

        public PoliticalExposureQuestionPage ClickContinueButton()
        {
            while (_continueButton.Enabled == false) Waits.ElementToBeClickable(_continueButton);
            _continueButton.Click();
            return this;
        }

        private void WaitUntilPoliticalExposureQuestionPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Waits.ElementToBeNotVisible(_progressIndicator);
                    Waits.ElementToBeVisible(_politicalExposureQuestion);
                    Waits.ElementToBeVisible(_yesAnswer);
                    Waits.ElementToBeVisible(_nopeAnswer);
                    Waits.ElementToBeVisible(_informationMessage);
                    Waits.ElementToBeClickable(_continueButton);

                    _politicalExposureQuestion.Text.Should().Contain(PoliticalExposureQuestionText);
                    _informationMessage.Text.Should().Contain(InformationMessageText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}