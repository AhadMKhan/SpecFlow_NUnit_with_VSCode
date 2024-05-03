using OpenQA.Selenium;
using SpecFlowDemo.Utils;

namespace SpecFlowDemo.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly Actions _actions;
        private readonly JsonReader _jsonReader;

        private const string HomePageUrl = "https://www.amazon.com/";

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _actions = new Actions(_driver);
            _jsonReader = new JsonReader("D:/SpecFlowDemo/Resources/Locators/HomePageLocators.json"); // Provide the correct file path
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(HomePageUrl);
            Thread.Sleep(20000);
        }

        public void SearchProduct(string Product)
        {
            var searchBoxId = _jsonReader.GetValueByKey("SearchBoxId");
            if (searchBoxId != null)
            {
                _actions.EnterText("id", searchBoxId, Product + Keys.Enter);
            }
            else
            {
                throw new ArgumentNullException("Search box id cannot be null.");
            }
        }
    }
}
