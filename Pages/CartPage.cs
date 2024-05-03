using OpenQA.Selenium;
using NUnit.Framework;
using SpecFlowDemo.Utils;

namespace SpecFlowDemo.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private readonly Actions _actions;

        private readonly ElementFactory _elementFactory;

        private readonly JsonReader _jsonReader;
        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _actions = new Actions(_driver);
            _elementFactory = new ElementFactory(_driver);
            _jsonReader = new JsonReader("D:/SpecFlowDemo/Resources/Locators/CartPageLocators.json"); // Provide the correct file path
        }

        public bool IsCartNotEmpty()
        {
            var cartCountId = _jsonReader.GetValueByKey("CartCountId");
            if (cartCountId != null)
            {
                var CartNotEmpty = _elementFactory.FindElement("id", cartCountId);
                return CartNotEmpty.Text != "0";
            }
            return false;
        }

        public void GotoCart()
        {
            var cartButtonId = _jsonReader.GetValueByKey("CartButtonId");
            if (cartButtonId != null)
            {
                _actions.ClickElement("id", cartButtonId);
            }
        }

        public void IsProductInCart(string ProductName)
        {
            var productNameXPath = _jsonReader.GetValueByKey("ProductNameXPath");
            if (productNameXPath != null)
            {
                string ActualProductName = _actions.GetText("XPATH", productNameXPath);
                _actions.AssertIsTrueContains(ActualProductName, ProductName);
            }
        }

        public void IsPriceDisplayed(string ExpectedPrice)
        {
            var priceXPath = _jsonReader.GetValueByKey("PriceXPath");
            if (priceXPath != null)
            {
                string ActualPrice = _actions.GetText("XPATH", priceXPath);
                _actions.AssertIsTrueContains(ActualPrice, ExpectedPrice);
            }
        }

    }
}
