using monorail_android.PageObjects;
using monorail_android.PageObjects.MainMenu;
using monorail_android.PageObjects.Wishlist;
using NUnit.Framework;
using static monorail_android.Commons.Constants;
using static monorail_android.Commons.Scroll;
using static monorail_android.Test.Scripts.Login.LoginAndLogout;
using static monorail_android.RestRequests.Helpers.PlaidConnectionHelperFunctions;
using static monorail_android.RestRequests.Helpers.WishlistHelperFunctions;

namespace monorail_android.Test.Scripts.Wishlist
{
    internal class AddIncompleteWishlistItem : FunctionalTesting
    {
        private const string IncompleteWishlistItemUrl =
            "https://www.monorail.com/blog/how-to-organize-your-finances";

        [Test]
        public void AddIncompleteWishlistItemWithWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var completeYourItemEntryPage = new CompleteYourItemEntryPage(Driver);
            var completeYourItemNamePage = new CompleteYourItemNamePage(Driver);
            var completeYourItemImagePage = new CompleteYourItemImagePage(Driver);
            var completeYourItemPricePage = new CompleteYourItemPricePage(Driver);
            var completeYourItemDescriptionPage = new CompleteYourItemDescriptionPage(Driver);
            var finishAddWishlistItemScreen = new FinishAddWishlistItemScreen(Driver);
            var wishlistItemDetailsPage = new WishlistItemDetailsPage(Driver);
            var removeFromWishlistBottomUp = new RemoveFromWishlistBottomUp(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+2.033022@gmail.com";

            AddEmptyWishlistItem(username, IncompleteWishlistItemUrl);

            VerifyPlaidConnection(username);

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainWishlistPage
                .ClickTapToCompleteItemPill();

            completeYourItemEntryPage
                .ClickContinueButton();

            completeYourItemNamePage
                .SetWishlistItemName(WishlistItemName)
                .ClickContinueButton();

            completeYourItemImagePage
                .ClickFirstImage()
                .ClickContinueButton();

            completeYourItemPricePage
                .SetWishlistItemPrice(WishlistItemPrice)
                .ClickContinueButton();

            completeYourItemDescriptionPage
                .SetWishlistItemDescription(WishlistItemDescription)
                .ClickContinueButton();

            finishAddWishlistItemScreen
                .WaitUntilFinishAddWishlistItemScreenWhenUserHasAccountIsLoaded()
                .ClickCloseButton();

            mainWishlistPage
                .CheckIfWishlistItemIsDisplayedOnMainScreen(WishlistItemName)
                .ClickWishlistItem(WishlistItemName);

            wishlistItemDetailsPage
                .WaitUntilWishlistItemDetailsPageForNotReadyToBuyStateIsLoaded();

            ScrollHalfOfScreen();

            wishlistItemDetailsPage
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemPrice, WishlistItemDescription)
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
        public void AddIncompleteWishlistItemWithoutWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainWishlistPage = new MainWishlistPage(Driver);
            var completeYourItemEntryPage = new CompleteYourItemEntryPage(Driver);
            var completeYourItemNamePage = new CompleteYourItemNamePage(Driver);
            var completeYourItemImagePage = new CompleteYourItemImagePage(Driver);
            var completeYourItemPricePage = new CompleteYourItemPricePage(Driver);
            var completeYourItemDescriptionPage = new CompleteYourItemDescriptionPage(Driver);
            var finishAddWishlistItemScreen = new FinishAddWishlistItemScreen(Driver);
            var wishlistItemDetailsPage = new WishlistItemDetailsPage(Driver);
            var removeFromWishlistBottomUp = new RemoveFromWishlistBottomUp(Driver);
            var mainMenuPage = new MainMenuPage(Driver);
            var logOutBottomUp = new LogOutBottomUp(Driver);

            const string username = "autotests.mono+2.032822@gmail.com";

            AddEmptyWishlistItem(username, IncompleteWishlistItemUrl);

            VerifyPlaidConnection(username);

            GoThroughLaunchScreens();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainWishlistPage
                .ClickTapToCompleteItemPill();

            completeYourItemEntryPage
                .ClickContinueButton();

            completeYourItemNamePage
                .SetWishlistItemName(WishlistItemName)
                .ClickContinueButton();

            completeYourItemImagePage
                .ClickFirstImage()
                .ClickContinueButton();

            completeYourItemPricePage
                .SetWishlistItemPrice(WishlistItemPrice)
                .ClickContinueButton();

            completeYourItemDescriptionPage
                .SetWishlistItemDescription(WishlistItemDescription)
                .ClickContinueButton();

            finishAddWishlistItemScreen
                .WaitUntilFinishAddWishlistItemScreenWhenUserDoesntHaveAccountIsLoaded()
                .ClickCloseButton();

            mainWishlistPage
                .CheckIfWishlistItemIsDisplayedOnMainScreen(WishlistItemName)
                .ClickWishlistItem(WishlistItemName);

            wishlistItemDetailsPage
                .WaitUntilWishlistItemDetailsPageForNotReadyToBuyStateIsLoaded();

            ScrollHalfOfScreen();

            wishlistItemDetailsPage
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemPrice, WishlistItemDescription)
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