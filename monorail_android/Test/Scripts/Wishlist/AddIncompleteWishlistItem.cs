using System.Threading;
using monorail_android.PageObjects;
using monorail_android.PageObjects.Commons.EditPages;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Wishlist;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;

namespace monorail_android.Test.Scripts.Wishlist
{
    internal class AddIncompleteWishlistItem : FunctionalTesting
    {
        private const string WishlistItemUrl =
            "https://www.monorail.com/blog/how-to-organize-your-finances";

        private const string WishlistItemName = "How To Organize Your Finances";
        private const string WishlistItemPrice = "1";

        [Test]
        public void AddIncompleteWishlistItemThroughAddAnItemButtonOnEmptyWishlistScreen()
        {
            var loginPage = new LoginPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var pasteALinkPage = new PasteALinkPage(Driver);
            var itemIsBeingAddedPage = new ItemIsBeingAddedPage(Driver);
            var editWishlistItemDetailsPage = new EditWishlistItemDetailsPage(Driver);
            var editPricePage = new EditPricePage(Driver);
            var finishAddWishlistItemScreen = new FinishAddWishlistItemScreen(Driver);
            var wishlistItemDetailsPage = new WishlistItemDetailsPage(Driver);
            var removeFromWishlistBottomUp = new RemoveFromWishlistBottomUp(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+2.032822@gmail.com";

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainWishlistPage
                .ClickAddAnItemButtonOnEmptyWishlistPage();

            pasteALinkPage
                .PasteUrl(WishlistItemUrl)
                .ClickContinueButton();

            itemIsBeingAddedPage
                .ClickCloseButton();

            Thread.Sleep(20000);

            mainWishlistPage
                .ClickWishlistItem(WishlistItemName);

            editWishlistItemDetailsPage
                .ClickPrice();

            editPricePage
                .SetPrice(WishlistItemPrice)
                .ClickSaveButton();

            editWishlistItemDetailsPage
                .ClickFinishButton();

            finishAddWishlistItemScreen
                .ClickCloseButton();

            mainWishlistPage
                .CheckIfWishlistItemIsDisplayedOnMainScreen(WishlistItemName)
                .ClickWishlistItem(WishlistItemName);

            wishlistItemDetailsPage
                .ClickRemoveButton();

            removeFromWishlistBottomUp
                .ClickRemoveButton();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }

        [Test]
        public void AddIncompleteWishlistItemThroughAddAnItemButtonOnMainWishlistScreen()
        {
            var loginPage = new LoginPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var pasteALinkPage = new PasteALinkPage(Driver);
            var itemIsBeingAddedPage = new ItemIsBeingAddedPage(Driver);
            var editWishlistItemDetailsPage = new EditWishlistItemDetailsPage(Driver);
            var editPricePage = new EditPricePage(Driver);
            var finishAddWishlistItemScreen = new FinishAddWishlistItemScreen(Driver);
            var wishlistItemDetailsPage = new WishlistItemDetailsPage(Driver);
            var removeFromWishlistBottomUp = new RemoveFromWishlistBottomUp(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+2.032922@gmail.com";

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainWishlistPage
                .ClickAddAnItemButtonOnMainWishlistPage();

            pasteALinkPage
                .PasteUrl(WishlistItemUrl)
                .ClickContinueButton();

            itemIsBeingAddedPage
                .ClickCloseButton();

            Thread.Sleep(20000);

            mainWishlistPage
                .ClickWishlistItem(WishlistItemName);

            editWishlistItemDetailsPage
                .ClickPrice();

            editPricePage
                .SetPrice(WishlistItemPrice)
                .ClickSaveButton();

            editWishlistItemDetailsPage
                .ClickFinishButton();

            finishAddWishlistItemScreen
                .ClickCloseButton();

            mainWishlistPage
                .CheckIfWishlistItemIsDisplayedOnMainScreen(WishlistItemName)
                .ClickWishlistItem(WishlistItemName);

            wishlistItemDetailsPage
                .ClickRemoveButton();

            removeFromWishlistBottomUp
                .ClickRemoveButton();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }

        [Test]
        public void AddIncompleteWishlistItemThroughPlaceholderButtonOnMainWishlistScreen()
        {
            var loginPage = new LoginPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var pasteALinkPage = new PasteALinkPage(Driver);
            var itemIsBeingAddedPage = new ItemIsBeingAddedPage(Driver);
            var editWishlistItemDetailsPage = new EditWishlistItemDetailsPage(Driver);
            var editPricePage = new EditPricePage(Driver);
            var finishAddWishlistItemScreen = new FinishAddWishlistItemScreen(Driver);
            var wishlistItemDetailsPage = new WishlistItemDetailsPage(Driver);
            var removeFromWishlistBottomUp = new RemoveFromWishlistBottomUp(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+2.033022@gmail.com";

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainWishlistPage
                .ClickPlaceholderOnMainWishlistPage();

            pasteALinkPage
                .PasteUrl(WishlistItemUrl)
                .ClickContinueButton();

            itemIsBeingAddedPage
                .ClickCloseButton();

            Thread.Sleep(20000);

            mainWishlistPage
                .ClickWishlistItem(WishlistItemName);

            editWishlistItemDetailsPage
                .ClickPrice();

            editPricePage
                .SetPrice(WishlistItemPrice)
                .ClickSaveButton();

            editWishlistItemDetailsPage
                .ClickFinishButton();

            finishAddWishlistItemScreen
                .ClickCloseButton();

            mainWishlistPage
                .CheckIfWishlistItemIsDisplayedOnMainScreen(WishlistItemName)
                .ClickWishlistItem(WishlistItemName);

            wishlistItemDetailsPage
                .ClickRemoveButton();

            removeFromWishlistBottomUp
                .ClickRemoveButton();

            mainMenuPage
                .ClickSideMenu()
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }
    }
}