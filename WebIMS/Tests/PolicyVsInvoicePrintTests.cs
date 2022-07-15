using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources.Enums;
using WebIMS.Pages;
using WebIMS.Pages.ProductsPages;

namespace WebIMS.Tests
{
    [TestClass]
    [TestCategory("WebIMS Policy vs Invoice print")]
    public class PolicyVsInvoicePrintTests : BaseTest
    {
        [TestMethod]
        [Description("AntiCoronavirus policy vs invoice print")]
        public void PrintAntiCoronavirusPolicyAndInvoice()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();

            var searchPolicyPage = webIMSHomePage.MenuBar.GoToSearchPolicyPage();
            searchPolicyPage.SearchPolicy(policyNumber: null, product: "Antikoronavirus", status: "Qüvvədədir", "01.03.2022", "30.04.2022");

            AntiCoronavirus antiCoronavirus = new AntiCoronavirus(Driver);
            antiCoronavirus.PrintPolicyOperation();
        }
        [TestMethod]
        [Description("ValuntaryHealth policy vs invoice print")]
        public void PrintValuntaryHealthPolicyAndInvoice()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();

            var searchPolicyPage = webIMSHomePage.MenuBar.GoToSearchPolicyPage();
            searchPolicyPage.SearchPolicy(policyNumber: null, product: "Yüz Yaşa", status: "Qüvvədədir", "01.03.2022", "30.04.2022");

            ValuntaryHealth valuntaryHealth = new ValuntaryHealth(Driver);
            valuntaryHealth.PrintPolicyOperation();
        }
        [TestMethod]
        [Description("VoluntaryPropertyLiability policy vs invoice print")]
        public void PrintVoluntaryPropertyLiabilityPolicyAndInvoice()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();

            var searchPolicyPage = webIMSHomePage.MenuBar.GoToSearchPolicyPage();
            searchPolicyPage.SearchPolicy(policyNumber: null, product: "Arxayın Qonşu", status: "Qüvvədədir", "01.03.2022", "30.04.2022");

            VoluntaryPropertyLiability voluntaryPropertyLiability = new VoluntaryPropertyLiability(Driver);
            voluntaryPropertyLiability.PrintPolicyOperation();
        }
        [TestMethod]
        [Description("Travel policy vs invoice print")]
        public void PrintTravelPolicyAndInvoice()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();

            var searchPolicyPage = webIMSHomePage.MenuBar.GoToSearchPolicyPage();
            searchPolicyPage.SearchPolicy(policyNumber: null, product: "Səfər sığortası", status: "Qurtardı", "01.03.2022", "30.04.2022");

            Travel travel = new Travel(Driver);
            travel.PrintPolicyOperation();
        }
        [TestMethod]
        public void PrintRetailCascoPolicyAndInvoice()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();

            var searchPolicyPage = webIMSHomePage.MenuBar.GoToSearchPolicyPage();
            searchPolicyPage.SearchPolicy(policyNumber: null, product: "Agent Kaskosu", status: "Qurtardı", "01.03.2022", "30.04.2022");

            RetailCasco retailCasco = new RetailCasco(Driver);
            retailCasco.PrintPolicyOperation();
        }
    }
}
