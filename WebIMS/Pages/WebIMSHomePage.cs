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
using WebIMS.PageParts;

namespace WebIMS.Pages
{
    public class WebIMSHomePage : BasePage
    {
        public WebIMSHomePage(IWebDriver driver) : base(driver) 
        {
            MenuBar = new MenuBar(driver);
        }

        #region Elements
        private IWebElement Content => WaitAndFindElement(By.Id("content"));
        #endregion

        #region Properties
        public bool IsLoaded
        {
            get
            {
                try
                {
                    Report.LogTestStepForBugLogger(Status.Info, "Validate that WebIMS Home Page loaded successfully.");
                    return Content.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
        public MenuBar MenuBar { get; set; }
        #endregion

        #region Methods
        public void GoTo()
        {
            string url = WebIMSUrls.BusinessTest + "/WebIMS/";
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Window.Maximize();
            Report.LogPassingTestStepForBugLogger($"Open url=> {url} for Home Page");
            Assert.IsTrue(IsLoaded, "Home Page was not loaded successfully.");
        }
        #endregion
    }
}
