using OpenQA.Selenium;
using SpecFlowDemo.Utils;

namespace SpecFlowDemo.Pages
{
    public class SearchResults
    {
        private readonly IWebDriver _driver;
        private readonly Actions _actions;
        private readonly JsonReader _jsonReader;

        public SearchResults(IWebDriver driver)
        {
            _driver = driver;
            _actions = new Actions(_driver);
            _jsonReader = new JsonReader("D:/SpecFlowDemo/Resources/Locators/SearchResultPageLocators.json"); // Provide the correct file path
        }

        public void ClickFirstResult()
        {
            var results = _driver.FindElements(By.CssSelector(_jsonReader.GetValueByKey("SearchResultSelector")));
            if (results.Count > 0)
                results[0].Click();
            else
                throw new NoSuchElementException("No search results found.");
        }

        public void AddToCart()
        {
            var addToCart = _jsonReader.GetValueByKey("AddToCartButtonId");

            if (addToCart != null)
            {
                _actions.ClickElement("id", addToCart);

            }
            else
            {
                throw new ArgumentNullException("Add to Cart id cannot be null.");
            }
        }
    }
}
