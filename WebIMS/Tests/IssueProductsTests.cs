using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources.Enums;
using WebIMS.Pages;
using WebIMS.Pages.ProductsPages;

namespace WebIMS.Tests
{
    [TestClass]
    [TestCategory("WebIMS Policy Issue")]
    public class IssueProductsTests : BaseTest
    {
        [TestMethod]
        [Description("Issue AntiCoronavirus product.")]
        public void IssueAntiCoronavirus()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.AntiCoronavirus);

            AntiCoronavirus antiCoronavirus = new AntiCoronavirus(Driver);
            string policyNumber = antiCoronavirus.FillOutPolicyDataAndIssuePolicy();
            antiCoronavirus.CheckEmailVsSMS();
            antiCoronavirus.RemovePolicyFromDB(policyNumber);
        }
        [TestMethod]
        [Description("Issue ValuntaryHealth product.")]
        public void IssueValuntaryHealth()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.ValuntaryHealth);

            ValuntaryHealth valuntaryHealth = new ValuntaryHealth(Driver);
            string policyNumber = valuntaryHealth.FillOutPolicyDataAndIssuePolicy();
            valuntaryHealth.CheckEmailVsSMS();
            valuntaryHealth.RemovePolicyFromDB(policyNumber);
        }
        [TestMethod]
        [Description("Issue VoluntaryPropertyLiability product.")]
        public void IssueVoluntaryPropertyLiability()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.VoluntaryPropertyLiability);

            VoluntaryPropertyLiability voluntaryPropertyLiability = new VoluntaryPropertyLiability(Driver);
            string policyNumber = voluntaryPropertyLiability.FillOutPolicyDataAndIssuePolicy();
            voluntaryPropertyLiability.CheckEmailVsSMS();
            voluntaryPropertyLiability.RemovePolicyFromDB(policyNumber);
        }
        [TestMethod]
        [Description("Issue Travel product.")]
        public void IssueTravel()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.Travel);

            Travel travel = new Travel(Driver);
            string policyNumber = travel.FillOutPolicyDataAndIssuePolicy();
            travel.CheckEmailVsSMS();
        }
        [TestMethod]
        public void IssueRetailCasco()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.RetailCaso);

            RetailCasco retailCasco = new RetailCasco(Driver);
            string policyNumber = retailCasco.FillOutPolicyDataAndIssuePolicy();
            retailCasco.CheckEmailVsSMS();
            retailCasco.RemovePolicyFromDatabase(policyNumber);
        }
        [TestMethod]
        public void IssueCascoCombi()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.CascoCombi);

            CascoCombiPage cascoCombiPage = new CascoCombiPage(Driver);
            string policyNumber = cascoCombiPage.FillOutPolicyDataAndIssuePolicy();
            cascoCombiPage.CheckEmailVsSMS();
           // cascoCombiPage.RemovePolicyFromDatabase(policyNumber);
        }
    }
}
