using OpenQA.Selenium;

namespace SpecFlowDemo.Utils
{
    public class ElementFactory
    {
        private readonly IWebDriver _driver;

        public ElementFactory(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement FindElement(string type, string value)
        {
            By locator = By.XPath(""); // Initialize with a default non-null value
            switch (type.ToLower())
            {
                case "id":
                    locator = By.Id(value);
                    break;
                case "css":
                case "cssselector":
                    locator = By.CssSelector(value);
                    break;
                case "name":
                    locator = By.Name(value);
                    break;
                case "class":
                case "classname":
                    locator = By.ClassName(value);
                    break;
                case "xpath":
                    locator = By.XPath(value);
                    break;
                case "tag":
                case "tagname":
                    locator = By.TagName(value);
                    break;
                default:
                    throw new NotSupportedException($"Locator type '{type}' is not supported.");
            }
            return _driver.FindElement(locator);
        }
    }
}
