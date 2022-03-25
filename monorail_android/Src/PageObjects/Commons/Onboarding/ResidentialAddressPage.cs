using System;
using FluentAssertions;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

namespace monorail_android.PageObjects.Commons.Onboarding
{
    public class ResidentialAddressPage
    {
        private const string ResidentialAddressLabel = "Your residential address";

        [FindsBy(How = How.Id, Using = "editStreet1")]
        private IWebElement _addressLine1Input;

        [FindsBy(How = How.Id, Using = "editStreet2")]
        private IWebElement _addressLine2Input;

        [FindsBy(How = How.Id, Using = "editCity")]
        private IWebElement _cityInput;

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "progressIndicator")]
        private IWebElement _progressIndicator;

        [FindsBy(How = How.Id, Using = "fieldLabel")]
        private IWebElement _residentialAddressLabel;

        [FindsBy(How = How.Id, Using = "editState")]
        private IWebElement _stateInput;

        [FindsBy(How = How.Id, Using = "editZip")]
        private IWebElement _zipInput;

        public ResidentialAddressPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public ResidentialAddressPage PassAddress(string addressLine1, string city, string state, string zip)
        {
            WaitUntilResidentialAddressPageIsLoaded();
            _addressLine1Input.SendKeys(addressLine1);
            _cityInput.SendKeys(city);
            _stateInput.SendKeys(state);
            _zipInput.SendKeys(zip);
            return this;
        }

        public ResidentialAddressPage ClickContinueButton()
        {
            while (_continueButton.Enabled == false) Waits.ElementToBeClickable(_continueButton);
            _continueButton.Click();
            return this;
        }

        private void WaitUntilResidentialAddressPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Waits.ElementToBeNotVisible(_progressIndicator);
                    Waits.ElementToBeVisible(_residentialAddressLabel);
                    Waits.ElementToBeVisible(_addressLine1Input);
                    Waits.ElementToBeVisible(_addressLine2Input);
                    Waits.ElementToBeVisible(_cityInput);
                    Waits.ElementToBeVisible(_stateInput);
                    Waits.ElementToBeVisible(_zipInput);
                    Waits.ElementToBeClickable(_continueButton);

                    _residentialAddressLabel.Text.Should().Contain(ResidentialAddressLabel);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}