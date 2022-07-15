using AventStack.ExtentReports;
using OpenQA.Selenium;
using Resources.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebIMS.PageParts;

namespace WebIMS.Pages
{
    public class SearchPolicyPage : BasePage
    {
        public SearchPolicyPage(IWebDriver driver) : base(driver)
        {
            MenuBar = new MenuBar(Driver);
        }

        #region Properties
        public MenuBar MenuBar { get; set; }
        public bool IsLoaded
        {
            get
            {
                try
                {
                    Report.LogTestStepForBugLogger(Status.Info, "Search Policy page loaded successfully.");
                    return Search.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
        #endregion

        #region Elements
        private IWebElement ProductDropDown => WaitUntilElementIsClickable(By.Id("ProductText"));
        private IWebElement StatusDropDown => WaitUntilElementIsClickable(By.Id("PolicyStatusText"));
        private IWebElement PolicyNumberSearchField => Driver.FindElement(By.Id("PolicyNumber"));
        private IWebElement Search => WaitAndFindElement(By.Id("btnSearch"));
        private IWebElement PolicyNumber => Driver.FindElement(By.Id("PolicyNumber"));
        private IWebElement DateFrom => Driver.FindElement(By.Id("From"));
        private IWebElement DateTo => Driver.FindElement(By.Id("To"));
        private IWebElement Body => Driver.FindElement(By.XPath("//body"));
        #endregion

        #region Methods
        public void SearchPolicyAndOpen(string policyNumber)
        {
            MenuBar.GoToSearchPolicyPage();
            PolicyNumberSearchField.SendKeys(policyNumber);
            Search.Click();

            IWebElement FoundPolicy = WaitAndFindElement(By.XPath($"//td[@title='{policyNumber}']/a"));
            FoundPolicy.Click();
            Report.LogTestStepForBugLogger(Status.Pass, $"'{policyNumber}' policy is opened.");
        }
        public void SearchPolicy(string policyNumber = null, string product = null, string status = null, string datetFrom = null, string dateTo = null)
        {
            if (policyNumber != null)
                PolicyNumber.SendKeys(policyNumber);

            if (product != null)
            {
                ProductDropDown.SendKeys(product);
                //ProductDropDown.Click();
                //IWebElement selectedProduct = WaitUntilElementIsClickable(By.XPath($"//li/a[contains(text(), '{product}')]"));
                //selectedProduct.Click();
            }
            if (status != null)
            {
                StatusDropDown.SendKeys(status);
                //PolicyNumber.Click();
                //Body.Click();
                //StatusDropDown.Click();
                //IWebElement selectedStatus = WaitUntilElementIsClickable(By.XPath($"//li/a[contains(text(), '{status}')]"));
                //selectedStatus.Click();
            }
            if (datetFrom != null && dateTo != null)
            {
                DateFrom.SendKeys(datetFrom);
                DateTo.SendKeys(dateTo);
            }

            Search.Click();
            Thread.Sleep(500);
            ////table/tbody/tr[2]/td[5]/a
            ////a[contains(text(), 'LA')]
            IWebElement firstPolicyInList = Driver.FindElements(By.XPath("//table/tbody/tr[2]/td[5]/a"))[0];
            firstPolicyInList.Click();
        }
        #endregion
    }
}