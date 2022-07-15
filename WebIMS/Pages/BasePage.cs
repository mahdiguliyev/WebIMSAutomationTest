using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Resources;

namespace WebIMS.Pages
{
    public class BasePage : Waiter
    {
        protected IWebDriver Driver { get; set; }
        public BasePage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }
    }
}
