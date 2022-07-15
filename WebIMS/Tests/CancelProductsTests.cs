using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources.Enums;
using WebIMS.Pages;
using WebIMS.Pages.ProductsPages;

namespace WebIMS.Tests
{
    [TestClass]
    [TestCategory("WebIMS Policy Cancel")]
    public class CancelProductsTests : BaseTest
    {
        [TestMethod]
        [Description("Cancel AntiCoronavirus policy.")]
        public void CancelAntiCoronavirus()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.AntiCoronavirus);

            AntiCoronavirus antiCoronavirus = new AntiCoronavirus(Driver);
            antiCoronavirus.FillOutPolicyDataAndIssuePolicy();
            antiCoronavirus.CancelPolicy();
        }
        [TestMethod]
        [Description("Cancel ValuntaryHealth policy.")]
        public void CancelValuntaryHealth()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.ValuntaryHealth);

            ValuntaryHealth valuntaryHealth = new ValuntaryHealth(Driver);
            valuntaryHealth.FillOutPolicyDataAndIssuePolicy();
            valuntaryHealth.CancelPolicy();
        }
        [TestMethod]
        [Description("Cancel VoluntaryPropertyLiability policy.")]
        public void CancelVoluntaryPropertyLiability()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.VoluntaryPropertyLiability);

            VoluntaryPropertyLiability voluntaryPropertyLiability = new VoluntaryPropertyLiability(Driver);
            voluntaryPropertyLiability.FillOutPolicyDataAndIssuePolicy();
            voluntaryPropertyLiability.CancelPolicy();
        }
        [TestMethod]
        [Description("Cancel Travel policy.")]
        public void CancelTravel()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.Travel);

            Travel travel = new Travel(Driver);
            travel.FillOutPolicyDataAndIssuePolicy();
            travel.CancelPolicy();
        }
        [TestMethod]
        public void CancelRetailCasco()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.RetailCaso);

            RetailCasco retailCasco = new RetailCasco(Driver);
            retailCasco.FillOutPolicyDataAndIssuePolicy();
            retailCasco.CancelPolicy();
        }
    }
}
