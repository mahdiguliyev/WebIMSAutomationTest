using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Resources.Reporter;
using Resources.URLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebIMS.Pages
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver) : base(driver) { }

        #region Elements
        private IWebElement SignInForm => WaitAndFindElement(By.XPath("//form[@action='/webims/Account/Login']"));
        private IWebElement UsernameField => Driver.FindElement(By.Id("UserName"));
        private IWebElement PasswordField => Driver.FindElement(By.Id("Password"));
        private IWebElement SingInButton => Driver.FindElement(By.Name("Login"));
        #endregion

        #region Properties
        private bool IsLoaded
        {
            get
            {
                try
                {
                    Report.LogTestStepForBugLogger(Status.Info, "Validate that Sing In Page loaded successfully.");
                    return SignInForm.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
        #endregion

        #region Methods
        public void GoTo()
        {
            string url = WebIMSUrls.BusinessTest + "webims/Account/Login";
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Window.Maximize();
            Report.LogPassingTestStepForBugLogger($"Open url=> {url} for Sign In Page");
            Assert.IsTrue(IsLoaded, "Sign In Page was not loaded successfully.");
        }
        public WebIMSHomePage SignIn()
        {
            UsernameField.SendKeys("1-1-2-15");
            PasswordField.SendKeys("Aa123456789");
            SingInButton.Click();

            Report.LogPassingTestStepForBugLogger("User signed in successfully.");

            return new WebIMSHomePage(Driver);
        }
        #endregion
    }
}
