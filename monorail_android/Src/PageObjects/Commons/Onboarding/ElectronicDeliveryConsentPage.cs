using System;
using FluentAssertions;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Commons.Onboarding
{
    public class ElectronicDeliveryConsentPage
    {
        private const string ElectronicDeliveryConsentHeaderText = "Electronic Delivery Consent";

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _agreeAndContinueButton;

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _electronicDeliveryConsentHeader;

        [FindsBy(How = How.Id, Using = "pdfView")]
        private IWebElement _electronicDeliveryConsentScroll;

        public ElectronicDeliveryConsentPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public ElectronicDeliveryConsentPage ScrollToTheBottomOfPage()
        {
            WaitUntilElectronicDeliveryConsentPageIsLoaded();
            var firstPointX = _electronicDeliveryConsentScroll.Size.Width / 2;
            var firstPointY = _electronicDeliveryConsentScroll.Location.Y + 10;

            var secondPointX = _electronicDeliveryConsentScroll.Size.Width / 2;
            var secondPointY = _electronicDeliveryConsentScroll.Location.Y +
                _electronicDeliveryConsentScroll.Size.Height - 10;

            while (_agreeAndContinueButton.Enabled == false)
                Scroll.ScrollFromToCoordinates(firstPointX, firstPointY, secondPointX, secondPointY);
            return this;
        }

        public ElectronicDeliveryConsentPage ClickAgreeAndContinueButton()
        {
            while (_agreeAndContinueButton.Enabled == false) ElementToBeClickable(_agreeAndContinueButton);
            _agreeAndContinueButton.Click();
            return this;
        }

        private void WaitUntilElectronicDeliveryConsentPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_electronicDeliveryConsentHeader));
                    Wait.Until(ElementToBeVisible(_agreeAndContinueButton));

                    _electronicDeliveryConsentHeader.Text.Should().Contain(ElectronicDeliveryConsentHeaderText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}