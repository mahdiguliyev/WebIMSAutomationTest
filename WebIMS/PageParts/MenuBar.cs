using AventStack.ExtentReports;
using OpenQA.Selenium;
using Resources.Enums;
using Resources.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebIMS.Pages;

namespace WebIMS.PageParts
{
    public class MenuBar : BasePage
    {
        public MenuBar(IWebDriver driver) : base(driver) { }

        #region Elements
        private IWebElement ProductsMenuItem => Driver.FindElement(By.XPath("//span[contains(text(),'Məhsullar')]"));
        private IWebElement ListsMenuItem => Driver.FindElement(By.XPath("//span[contains(text(),'Siyahılar')]"));
        private IWebElement ListOfPolicies => Driver.FindElement(By.XPath("//span[contains(text(),'Polislərin siyahısı')]"));

        #endregion

        #region Properties
        #endregion

        #region Methods
        private IWebElement GetProduct(ProductsLOB productsLOB)
        {
            int product = (int)productsLOB;
            IWebElement AntiCoronavirus = WaitAndFindElement(By.XPath($"//a[@href='/webims/Common/Policy/Create/{product}']"));
            return AntiCoronavirus;
        }
        public void SelectProductFromProductList(ProductsLOB productsLOB)
        {
            ProductsMenuItem.Click();
            GetProduct(productsLOB).Click();
            Report.LogTestStepForBugLogger(Status.Info, $"{productsLOB} product is selected.");
        }
        public void ClickListsMenuItem()
        {
            ListsMenuItem.Click();
        }
        public SearchPolicyPage GoToSearchPolicyPage()
        {
            ListsMenuItem.Click();
            ListOfPolicies.Click();

            return new SearchPolicyPage(Driver);
        }
        #endregion
    }
}
