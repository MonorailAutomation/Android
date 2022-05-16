using System;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Commons.Waits;
using static monorail_android.Test.FunctionalTesting;

namespace monorail_android.PageObjects.Money.Save.ItemPages
{
    public class EditTrackDetailsPage
    {
        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "buttonContinue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "buttonChangeImage")]
        private IWebElement _setFeaturedImageButton;

        [FindsBy(How = How.Id, Using = "trackImage")]
        private IWebElement _trackImage;

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[contains(@text, 'Name')]")]
        private IWebElement _trackName;

        public EditTrackDetailsPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public EditTrackDetailsPage ClickContinueButton()
        {
            WaitUntilEditTrackDetailsPageIsLoaded();
            _continueButton.Click();
            return this;
        }

        [AllureStep("Click 'Name' section")]
        public EditTrackDetailsPage ClickEditTrackName()
        {
            WaitUntilEditTrackDetailsPageIsLoaded();
            _trackName.Click();
            return this;
        }

        private void WaitUntilEditTrackDetailsPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_trackImage));
                    Wait.Until(ElementToBeVisible(_setFeaturedImageButton));
                    //Wait.Until(ElementToBeVisible(_trackName));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_continueButton));
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}