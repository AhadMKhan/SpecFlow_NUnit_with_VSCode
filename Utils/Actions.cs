using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework; // Add NUnit.Framework for Assert
using System;

namespace SpecFlowDemo.Utils
{
    public class Actions
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly ElementFactory _elementFactory; // Add ElementFactory

        public Actions(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            _elementFactory = new ElementFactory(_driver);
        }

        public void ClickElement(string type, string value)
        {
            if (type != null && value != null)
            {
                _elementFactory.FindElement(type, value).Click();
            }
            else
            {
                throw new ArgumentNullException("Type or value cannot be null.");
            }
        }

        public void EnterText(string type, string value, string text)
        {
            if (type != null && value != null)
            {
                _elementFactory.FindElement(type, value).SendKeys(text);
            }
            else
            {
                throw new ArgumentNullException("Type or value cannot be null.");
            }
        }

        public void WaitForPageLoad()
        {
            _wait.Until(driver => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public string GetText(string type, string value)
        {
            if (type != null && value != null)
            {
                IWebElement element = _elementFactory.FindElement(type, value);
                return element.Text;
            }
            else
            {
                throw new ArgumentNullException("Type or value cannot be null.");
            }
        }

        public void AssertIsTrueContains(string actualResult, string ExpectedResult)
        {
            if (actualResult != null && ExpectedResult != null)
            {
                Assert.IsTrue(actualResult.Contains(ExpectedResult), $"Expected Result: {ExpectedResult}. Actual Result: {actualResult}");
            }
            else
            {
                throw new ArgumentNullException("Actual result or Expected result cannot be null.");
            }
        }

    }
}
