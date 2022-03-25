using System;
using FluentAssertions;
using monorail_android.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

namespace monorail_android.PageObjects.MainMenu
{
    public class ConnectedAccountPage
    {
        private const string InformationMessageHeaderText = "Funding goals is secure and simple.";

        private const string InformationMessageText =
            "Your goals grow by connecting your current spending account. It’s easy, speedy, and bank level secure.";

        private const string PageTitleText = "Connected Account";

        private readonly string[] _listOfCompaniesInTransactions =
            {"United Airlines", "Uber", "McDonald\'s", "Starbucks"};

        [FindsBy(How = How.Id, Using = "img_back")]
        private IWebElement _backButton;

        [FindsBy(How = How.Id, Using = "btn_connect_account")]
        private IWebElement _connectYourAccountButton;

        [FindsBy(How = How.Id, Using = "lbl_subtitle")]
        private IWebElement _informationMessage;

        [FindsBy(How = How.Id, Using = "labelTitle")]
        private IWebElement _informationMessageHeader;

        [FindsBy(How = How.Id, Using = "title")]
        private IWebElement _pageTitle;

        [FindsBy(How = How.Id, Using = "progressIndicator")]
        private IWebElement _progressIndicator;

        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[3]/android.widget.TextView[1]")]
        private IWebElement _sampleThirdTransaction;

        [FindsBy(How = How.Id, Using = "lbl_unlink")]
        private IWebElement _unlinkButton;

        public ConnectedAccountPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public ConnectedAccountPage ClickConnectYourAccountButton()
        {
            WaitUntilConnectedAccountPageBeforeConnectingPlaidIsLoaded();
            _connectYourAccountButton.Click();
            return this;
        }

        public ConnectedAccountPage ClickBackButton()
        {
            Waits.ElementToBeClickable(_backButton);
            _backButton.Click();
            return this;
        }

        private void WaitUntilConnectedAccountPageBeforeConnectingPlaidIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Waits.ElementToBeClickable(_backButton);
                    Waits.ElementToBeVisible(_pageTitle);
                    Waits.ElementToBeVisible(_informationMessageHeader);
                    Waits.ElementToBeVisible(_informationMessage);
                    Waits.ElementToBeVisible(_connectYourAccountButton);

                    _pageTitle.Text.Should().Contain(PageTitleText);
                    _informationMessageHeader.Text.Should().Contain(InformationMessageHeaderText);
                    _informationMessage.Text.Should().Contain(InformationMessageText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }
        }

        public ConnectedAccountPage WaitUntilConnectedAccountPageAfterConnectingPlaidIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Waits.ElementToBeClickable(_backButton);
                    Waits.ElementToBeVisible(_pageTitle);
                    Waits.ElementToBeVisible(_unlinkButton);
                    Waits.ElementToBeVisible(_sampleThirdTransaction);
                    Waits.ElementToBeNotVisible(_connectYourAccountButton);
                    Waits.ElementToBeNotVisible(_progressIndicator);

                    _pageTitle.Text.Should().Contain(PageTitleText);
                    _sampleThirdTransaction.Text.Should().ContainAny(_listOfCompaniesInTransactions);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }

            return this;
        }
    }
}