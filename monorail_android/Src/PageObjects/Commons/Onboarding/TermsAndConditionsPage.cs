using System;
using FluentAssertions;
using monorail_android.Commons;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Commons.Onboarding
{
    public class TermsAndConditionsPage
    {
        private const string TermsAndConditionsHeaderText = "Terms And Conditions";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _agreeAndFinishButton;

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _termsAndConditionsHeader;

        [FindsBy(How = How.Id, Using = "pdfView")]
        private IWebElement _termsAndConditionsScroll;

        public TermsAndConditionsPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Scroll to the bottom of 'Terms and Conditions' document")]
        public TermsAndConditionsPage ScrollToTheBottomOfPage()
        {
            WaitUntilElectronicDeliveryConsentPageIsLoaded();
            var firstPointX = _termsAndConditionsScroll.Size.Width / 2;
            var firstPointY = _termsAndConditionsScroll.Location.Y + 10;

            var secondPointX = _termsAndConditionsScroll.Size.Width / 2;
            var secondPointY = _termsAndConditionsScroll.Location.Y +
                _termsAndConditionsScroll.Size.Height - 10;

            while (_agreeAndFinishButton.Enabled == false)
                Scroll.ScrollFromToCoordinates(firstPointX, firstPointY, secondPointX, secondPointY);
            return this;
        }

        [AllureStep("Click 'Agree and Finish' button")]
        public TermsAndConditionsPage ClickAgreeAndFinishButton()
        {
            while (_agreeAndFinishButton.Enabled == false) ElementToBeClickable(_agreeAndFinishButton);
            _agreeAndFinishButton.Click();
            return this;
        }

        private void WaitUntilElectronicDeliveryConsentPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_termsAndConditionsHeader));
                    Wait.Until(ElementToBeVisible(_agreeAndFinishButton));

                    _termsAndConditionsHeader.Text.Should().Contain(TermsAndConditionsHeaderText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}