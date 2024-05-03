using OpenQA.Selenium;
using SpecFlowDemo.Pages;
using SpecFlowDemo.Utils;
using TechTalk.SpecFlow;

namespace SpecFlowDemo.Steps
{
    [Binding]
    public class AmazonSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly SearchResults _searchResults;
        private readonly CartPage _cartPage;
        private readonly Actions _actions;

        public AmazonSteps()
        {
            _driver = WebDriverManager.GetWebDriver(BrowserType.Chrome); // Retrieve WebDriver instance from WebDriverManager
            _homePage = new HomePage(_driver);
            _searchResults = new SearchResults(_driver);
            _cartPage = new CartPage(_driver);
            _actions = new Actions(_driver);
        }

        [Given(@"I am on the Amazon website")]
        public void GivenIAmOnTheAmazonWebsite()
        {
            _homePage.Navigate();
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string product)
        {
            _homePage.SearchProduct(product);
        }

        [When(@"I add the corresponding item to the cart")]
        public void WhenIAddTheCorrespondingItemToTheCart()
        {
            _searchResults.ClickFirstResult();
            _searchResults.AddToCart();
        }

        [Then(@"I should see the ""(.*)"" and amount ""(.*)"" in the cart")]
        public void ThenIShouldSeeTheCorrectItemAndAmountInTheCart(string productName, string amount)
        {
            _actions.WaitForPageLoad();
            Assert.IsTrue(_cartPage.IsCartNotEmpty());
            _cartPage.GotoCart();
            _cartPage.IsProductInCart(productName);
            _cartPage.IsPriceDisplayed(amount);
        }
    }
}
