using System;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using static monorail_android.Test.FunctionalTesting;
using static monorail_android.Commons.Waits;

namespace monorail_android.PageObjects.Wishlist.ItemPages
{
    public class EditWishlistItemDetailsPage
    {
        [FindsBy(How = How.Id, Using = "goalImage")]
        private IWebElement _wishlistItemImage;

        [FindsBy(How = How.Id, Using = "buttonBack")]
        private IWebElement _backButton;

        [FindsBy(How = How.Id, Using = "fieldName")]
        private IWebElement _nameField;

        [FindsBy(How = How.Id, Using = "clickOverlayEditPrice")]
        private IWebElement _priceField;

        [FindsBy(How = How.Id, Using = "fieldDescription")]
        private IWebElement _descriptionField;

        [FindsBy(How = How.Id, Using = "labelFeaturedImages")]
        private IWebElement _featuredImageLabel;

        [FindsBy(How = How.Id, Using = "fieldUrl")]
        private IWebElement _urlField;

        [FindsBy(How = How.XPath, Using = "//*[contains(@resource-id, 'fieldName')]//*[contains(@resource-id, 'iconPencil')]")]
        private IWebElement _editNamePencil;

        [FindsBy(How = How.Id, Using = "iconPencilPrice")]
        private IWebElement _editPricePencil;

        [FindsBy(How = How.XPath, Using = "//*[contains(@resource-id, 'fieldDescription')]//*[contains(@resource-id, 'iconPencil')]")]
        private IWebElement _editDescriptionPencil;

        public EditWishlistItemDetailsPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public EditWishlistItemDetailsPage WaitUntilEditWishlistItemDetailsPageIsLoaded()
        {
            var count = 0;
            const int maxTries = 3;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(_wishlistItemImage));
                    Wait.Until(ElementToBeVisible(_featuredImageLabel));
                    Wait.Until(ElementToBeVisible(_nameField));
                    Wait.Until(ElementToBeVisible(_priceField));
                    Wait.Until(ElementToBeClickable(_backButton));
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }

            return this;
        }

        [AllureStep("Click 'Edit Name' pencil")]
        public EditWishlistItemDetailsPage ClickEditNamePencil()
        {
            Wait.Until(ElementToBeVisible(_editNamePencil));
            _editNamePencil.Click();
            return this;
        }

        [AllureStep("Click 'Edit Price' pencil")]
        public EditWishlistItemDetailsPage ClickEditPricePencil()
        {
            Wait.Until(ElementToBeVisible(_editPricePencil));
            _editPricePencil.Click();
            return this;
        }

        [AllureStep("Click 'Edit Description' pencil")]
        public EditWishlistItemDetailsPage ClickEditDescriptionPencil()
        {
            Wait.Until(ElementToBeVisible(_editDescriptionPencil));
            _editDescriptionPencil.Click();
            return this;
        }

        [AllureStep("Click '<' button")]
        public EditWishlistItemDetailsPage ClickBackButton()
        {
            Wait.Until(ElementToBeVisible(_backButton));
            _backButton.Click();
            return this;
        }
    }
}