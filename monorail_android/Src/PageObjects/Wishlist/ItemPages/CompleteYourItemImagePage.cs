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
    public class CompleteYourItemImagePage
    {
        private const string PageHeaderText = "Complete your Item info";

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "buttonSave")]
        private IWebElement _continueButton;

        [FindsBy(How = How.XPath, Using = "//android.widget.ScrollView//android.widget.FrameLayout[1]")]
        private IWebElement _firstImage;

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _pageHeader;

        public CompleteYourItemImagePage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public CompleteYourItemImagePage ClickContinueButton()
        {
            Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }

        [AllureStep("Click first image on carousel")]
        public CompleteYourItemImagePage ClickFirstImage()
        {
            WaitUntilCompleteYourItemImagePageIsLoaded();
            Wait.Until(ElementToBeVisible(_firstImage));
            _firstImage.Click();
            return this;
        }

        private void WaitUntilCompleteYourItemImagePageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_pageHeader));
                    Wait.Until(ElementToBeVisible(_firstImage));
                    Wait.Until(ElementToBeVisible(_cancelButton));
                    Wait.Until(ElementToBeVisible(_continueButton));

                    _pageHeader.Text.Should().Contain(PageHeaderText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}