using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowDemo.Utils
{
    [Binding]
    public class Hooks
    {
        private readonly IWebDriver _driver;

        public Hooks()
        {
            _driver = WebDriverManager.GetWebDriver(BrowserType.Chrome); // Change to the desired browser type
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}
