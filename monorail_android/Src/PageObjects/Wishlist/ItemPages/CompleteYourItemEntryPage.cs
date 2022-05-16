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
    public class CompleteYourItemEntryPage
    {
        private const string MissingInformationMessageTextPartOne = "There is some missing information";
        private const string MissingInformationMessageTextPartTwo = "about your item we were not able";
        private const string MissingInformationMessageTextPartThree = "to get automatically.";

        private const string PageHeaderText = "Complete your Item info";

        private const string TryAgainMessageTextPartOne = "You can either try again or continue to complete";
        private const string TryAgainMessageTextPartTwo = "them manually.";

        [FindsBy(How = How.Id, Using = "buttonSave")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "labelPaste")]
        private IWebElement _missingInformationMessage;

        [FindsBy(How = How.Id, Using = "labelPageTitle")]
        private IWebElement _pageHeader;


        [FindsBy(How = How.Id, Using = "labelRemoveItem")]
        private IWebElement _removeItemButton;

        [FindsBy(How = How.Id, Using = "buttonCancel")]
        private IWebElement _tryAgainButton;

        [FindsBy(How = How.Id, Using = "labelFooter")]
        private IWebElement _tryAgainMessage;

        public CompleteYourItemEntryPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public CompleteYourItemEntryPage ClickContinueButton()
        {
            WaitUntilCompleteYourItemEntryPageIsLoaded();
            Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }

        private void WaitUntilCompleteYourItemEntryPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_pageHeader));
                    Wait.Until(ElementToBeVisible(_removeItemButton));
                    Wait.Until(ElementToBeVisible(_missingInformationMessage));
                    Wait.Until(ElementToBeVisible(_tryAgainMessage));
                    Wait.Until(ElementToBeVisible(_tryAgainButton));
                    Wait.Until(ElementToBeVisible(_continueButton));

                    _pageHeader.Text.Should().Contain(PageHeaderText);
                    _missingInformationMessage.Text.Should().Contain(MissingInformationMessageTextPartOne);
                    _missingInformationMessage.Text.Should().Contain(MissingInformationMessageTextPartTwo);
                    _missingInformationMessage.Text.Should().Contain(MissingInformationMessageTextPartThree);
                    _tryAgainMessage.Text.Should().Contain(TryAgainMessageTextPartOne);
                    _tryAgainMessage.Text.Should().Contain(TryAgainMessageTextPartTwo);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }
    }
}