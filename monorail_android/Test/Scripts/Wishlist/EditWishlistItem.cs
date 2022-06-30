using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using monorail_android.PageObjects;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Wishlist.ItemPages;
using static monorail_android.Commons.Scroll;
using monorail_android.PageObjects.Wishlist;
using monorail_android.PageObjects.Invest;
using static monorail_android.RestRequests.Helpers.PlaidConnectionHelperFunctions;
using static monorail_android.Commons.Constants;
using static monorail_android.RestRequests.Helpers.WishlistHelperFunctions;
using System.Threading;

namespace monorail_android.Test.Scripts.Wishlist
{
    [TestFixture]
    [AllureNUnit]
    internal class EditWishlistItem : FunctionalTesting
    {
        [Test(Description = "Edit Wishlist Item")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Edit Wishlist Item")]
        [AllureStory("Edit Wishlist Item: Name, Price and Description fields")]

        public void EditWishlistItemTest()
        {
            var loginPage = new LoginPage(Driver);
            var emptyMilestonesPage = new EmptyMilestonesPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var wishlistItemDetailsPage = new WishlistItemDetailsPage(Driver);
            var editWishlistItemDetailsPage = new EditWishlistItemDetailsPage(Driver);
            var editWishlistItemNamePage = new EditWishlistItemNamePage(Driver);
            var editWishlistItemPricePage = new EditWishlistItemPricePage(Driver);
            var editWishlistItemDescriptionPage = new EditWishlistItemDescriptionPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+6.1.051822@gmail.com";
            const string spotId = "23379f7e-0b0d-49ab-a06a-20aab51b4da2";
            const string oldWishlistItemName = "Kindle - With a Front Light";
            const string newWishlistItemName = "Kindle Reader";
            const string oldWishlistItemPrice = "89.99";
            const string newWishlistItemPrice = "123.57";
            const string oldWishlistItemDescription = "Purpose-built for reading with a 167 ppi glare-free display that reads like real paper, even in direct sunlight.";
            const string newWishlistItemDescription = "Portable, wireless e-reader that allows users to browse, download and read e-books, magazines, blogs, newspapers and other digital media.";

            VerifyPlaidConnection(username);

            EditWishlistItem(username, spotId, oldWishlistItemName, oldWishlistItemDescription, oldWishlistItemPrice);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            emptyMilestonesPage
                .WaitUntilEmptyMilestonesPageIsLoaded();

            mainMenuPage
                .ClickSideMenu()
                .ClickWishlist();

            mainWishlistPage
                .CheckIfWishlistItemIsDisplayedOnMainScreen(oldWishlistItemName)
                .ClickWishlistItem(oldWishlistItemName);

            wishlistItemDetailsPage
                .ClickEditButton();

            editWishlistItemDetailsPage
                .ClickEditNamePencil();

            editWishlistItemNamePage
                .EditWishlistItemName(newWishlistItemName)
                .ClickSaveButton();

            editWishlistItemDetailsPage
                .ClickEditPricePencil();

            editWishlistItemPricePage
                .EditWishlistItemPrice(newWishlistItemPrice)
                .ClickSaveButton();

            editWishlistItemDetailsPage
                .WaitUntilEditWishlistItemDetailsPageIsLoaded();

            ScrollHalfOfScreen();

            editWishlistItemDetailsPage
                .ClickEditDescriptionPencil();

            editWishlistItemDescriptionPage
                .EditWishlistItemDescription(newWishlistItemDescription)
                .ClickSaveButton();

            editWishlistItemDetailsPage
                .WaitUntilEditWishlistItemDetailsPageIsLoaded()
                .ClickBackButton();

            ScrollHalfOfScreen();

            wishlistItemDetailsPage
                .VerifyWishlistItemDetails(newWishlistItemName, newWishlistItemPrice, newWishlistItemDescription)
                .ClickBackButton();

            mainWishlistPage
                .WaitUntilMainWishlistPageIsLoaded()
                .CheckIfWishlistItemIsDisplayedOnMainScreen(newWishlistItemName)
                .ClickBackButton();

            mainMenuPage
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();

            EditWishlistItem(username, spotId, oldWishlistItemName, oldWishlistItemDescription, oldWishlistItemPrice);
        }
    }
}