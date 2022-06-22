using System.Threading;
using monorail_android.PageObjects;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Invest;
using monorail_android.PageObjects.Wishlist;
using monorail_android.PageObjects.Wishlist.ItemPages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_android.Test.Scripts.Wishlist
{
    [TestFixture]
    [AllureNUnit]
    internal class AddCompleteWishlistItem : FunctionalTesting
    {
        private const string CompleteWishlistItemUrl =
            "https://www.amazon.com/Sceptre-E248W-19203R-Monitor-Speakers-Metallic/dp/B0773ZY26F/ref=lp_16225007011_1_4";

        private const string CompleteWishlistItemName = "Sceptre 24\" Professional";

        [Test(Description = "Add complete Wishlist item by clicking 'Add an Item' button on Empty Wishlist Screen")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add complete Wishlist Item")]
        [AllureStory("Add complete Wishlist item by clicking 'Add an Item' button on Empty Wishlist Screen")]
        public void AddCompleteWishlistItemThroughAddAnItemButtonOnEmptyWishlistScreen()
        {
            var loginPage = new LoginPage(Driver);
            var emptyTradingPage = new EmptyTradingPage(Driver);
            var emptyMainWishlistPage = new EmptyMainWishlistPage(Driver);
            var pasteALinkPage = new PasteALinkPage(Driver);
            var itemIsBeingAddedPage = new ItemIsBeingAddedPage(Driver);
            var wishlistItemDetailsPage = new WishlistItemDetailsPage(Driver);
            var removeFromWishlistBottomUp = new RemoveFromWishlistBottomUp(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+2.040522@gmail.com";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            emptyTradingPage
               .WaitUntilEmptyTradingPageIsLoaded();

            mainMenuPage
                .ClickSideMenu()
                .ClickWishlist();

            emptyMainWishlistPage
                .ClickAddAnItemButton();

            pasteALinkPage
                .PasteUrl(CompleteWishlistItemUrl)
                .ClickContinueButton();

            itemIsBeingAddedPage
                .ClickCloseButton();

            Thread.Sleep(20000);

            mainWishlistPage
                .CheckIfWishlistItemIsDisplayedOnMainScreen(CompleteWishlistItemName)
                .ClickWishlistItem(CompleteWishlistItemName);

            wishlistItemDetailsPage
                .ClickRemoveButton();

            removeFromWishlistBottomUp
                .ClickRemoveButton();

            mainWishlistPage
                .WaitUntilMainWishlistPageIsLoaded()
                .ClickBackButton();

            mainMenuPage
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }

        [Test(Description = "Add complete Wishlist item by clicking 'Add an Item' button on Main Wishlist Screen")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add complete Wishlist Item")]
        [AllureStory("Add complete Wishlist item by clicking 'Add an Item' button on Main Wishlist Screen")]
        public void AddCompleteWishlistItemThroughAddAnItemButtonOnMainWishlistScreen()
        {
            var loginPage = new LoginPage(Driver);
            var emptyTradingPage = new EmptyTradingPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var pasteALinkPage = new PasteALinkPage(Driver);
            var itemIsBeingAddedPage = new ItemIsBeingAddedPage(Driver);
            var wishlistItemDetailsPage = new WishlistItemDetailsPage(Driver);
            var removeFromWishlistBottomUp = new RemoveFromWishlistBottomUp(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+2.050622@gmail.com";

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            emptyTradingPage
               .WaitUntilEmptyTradingPageIsLoaded();

            mainMenuPage
                .ClickSideMenu()
                .ClickWishlist();

            mainWishlistPage
                .ClickAddAnItemButton();

            pasteALinkPage
                .PasteUrl(CompleteWishlistItemUrl)
                .ClickContinueButton();

            itemIsBeingAddedPage
                .ClickCloseButton();

            Thread.Sleep(20000);

            mainWishlistPage
                .CheckIfWishlistItemIsDisplayedOnMainScreen(CompleteWishlistItemName)
                .ClickWishlistItem(CompleteWishlistItemName);

            wishlistItemDetailsPage
                .ClickRemoveButton();

            removeFromWishlistBottomUp
                .ClickRemoveButton();

            mainWishlistPage
                .WaitUntilMainWishlistPageIsLoaded()
                .ClickBackButton();

            mainMenuPage
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }

        [Test(Description = "Add complete Wishlist item by clicking '+' placeholder button on Main Wishlist Screen")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add complete Wishlist Item")]
        [AllureStory("Add complete Wishlist item by clicking '+' placeholder button on Main Wishlist Screen")]
        public void AddCompleteWishlistItemThroughPlaceholderButtonOnMainWishlistScreen()
        {
            var loginPage = new LoginPage(Driver);
            var emptyTradingPage = new EmptyTradingPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var pasteALinkPage = new PasteALinkPage(Driver);
            var itemIsBeingAddedPage = new ItemIsBeingAddedPage(Driver);
            var wishlistItemDetailsPage = new WishlistItemDetailsPage(Driver);
            var removeFromWishlistBottomUp = new RemoveFromWishlistBottomUp(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+2.050522@gmail.com";

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            emptyTradingPage
                .WaitUntilEmptyTradingPageIsLoaded();

            mainMenuPage
                .ClickSideMenu()
                .ClickWishlist();

            mainWishlistPage
                .ClickPlaceholder();

            pasteALinkPage
                .PasteUrl(CompleteWishlistItemUrl)
                .ClickContinueButton();

            itemIsBeingAddedPage
                .ClickCloseButton();

            Thread.Sleep(20000);

            mainWishlistPage
                .CheckIfWishlistItemIsDisplayedOnMainScreen(CompleteWishlistItemName)
                .ClickWishlistItem(CompleteWishlistItemName);

            wishlistItemDetailsPage
                .ClickRemoveButton();

            removeFromWishlistBottomUp
                .ClickRemoveButton();

            mainWishlistPage
                .WaitUntilMainWishlistPageIsLoaded()
                .ClickBackButton();

            mainMenuPage
                .ClickLogOut();

            logOutBottomUp
                .ClickYesButton();
        }
    }
}