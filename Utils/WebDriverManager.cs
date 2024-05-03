using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SpecFlowDemo.Utils
{
    public static class WebDriverManager
    {
        private static IWebDriver? _webDriver = null; // Nullable field

        public static IWebDriver GetWebDriver(BrowserType browserType)
        {
            if (_webDriver == null)
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        ChromeOptions chromeOptions = new ChromeOptions();
                        _webDriver = new ChromeDriver(chromeOptions);
                        break;
                    case BrowserType.Firefox:
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        _webDriver = new FirefoxDriver(firefoxOptions);
                        break;
                    default:
                        throw new NotSupportedException($"Browser type '{browserType}' is not supported.");
                }
            }
            return _webDriver;
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox
        // Add more browser types as needed
    }
}
