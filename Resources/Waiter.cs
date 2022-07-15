using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Resources
{
    public class Waiter
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;
        private WebDriverWait _webDriverWait;
        public Waiter(IWebDriver driver)
        {
            _webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
        }
        protected IWebElement WaitAndFindElement(By locator)
        {
            return _webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        protected bool WaitUntilValueIsEqual(By locator, string expectedValue)
        {
            return _webDriverWait.Until(driver => driver.FindElement(locator).GetDomProperty("value").Split(",")[0] == expectedValue);
        }
        protected IWebElement WaitUntilElementIsClickable(By locator)
        {
            return _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
