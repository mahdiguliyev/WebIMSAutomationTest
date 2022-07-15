using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources.Enums;
using Resources.Enums.Users;
using Resources.Functions;
using System;
using System.Threading.Tasks;
using WebIMS.Pages;
using WebIMS.Pages.ProductsPages;

namespace WebIMS.Tests
{
    [TestClass]
    [TestCategory("WebIMS Policy Termination")]
    public class TerminateProductsTests : BaseTest
    {
        [TestMethod]
        [Description("Terminate AntiCoronavirus policy.")]
        public async Task TerminateAntiCoronavirus()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.AntiCoronavirus);

            AntiCoronavirus antiCoronavirus = new AntiCoronavirus(Driver);
            string policyNumber = antiCoronavirus.FillOutPolicyDataAndIssuePolicy();

            antiCoronavirus.ChangePolicyStatus(policyNumber);

            await antiCoronavirus.DoPayment(policyNumber, 38, CompanyType.AteshgahLife);

            var searchPolicyPage = webIMSHomePage.MenuBar.GoToSearchPolicyPage();
            searchPolicyPage.SearchPolicyAndOpen(policyNumber);

            antiCoronavirus.TerminatePolicy();
        }
        //[TestMethod]
        [Description("Terminate Valuntary Health policy.")]
        public async Task TerminateValuntaryHealth()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.ValuntaryHealth);

            ValuntaryHealth valuntaryHealth = new ValuntaryHealth(Driver);
            string policyNumber = valuntaryHealth.FillOutPolicyDataAndIssuePolicy();

            await valuntaryHealth.DoPayment(policyNumber, 180, CompanyType.Ateshgah);

            string response = await valuntaryHealth.PolicyActivation();

            var searchPolicyPage = webIMSHomePage.MenuBar.GoToSearchPolicyPage();
            searchPolicyPage.SearchPolicyAndOpen(policyNumber);

            valuntaryHealth.TerminatePolicy();
        }
        [TestMethod]
        [Description("Terminate AntiCoronavirus policy.")]
        public async Task TerminateVoluntaryPropertyLiability()
        {

            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.VoluntaryPropertyLiability);

            VoluntaryPropertyLiability voluntaryPropertyLiability = new VoluntaryPropertyLiability(Driver);
            string policyNumber = voluntaryPropertyLiability.FillOutPolicyDataAndIssuePolicy();

            voluntaryPropertyLiability.ChangePolicyStatus(policyNumber);

            await voluntaryPropertyLiability.DoPayment(policyNumber, 38, CompanyType.Ateshgah);

            var searchPolicyPage = webIMSHomePage.MenuBar.GoToSearchPolicyPage();
            searchPolicyPage.SearchPolicyAndOpen(policyNumber);

            voluntaryPropertyLiability.TerminatePolicy();
        }
        [TestMethod]
        [Description("Terminate AntiCoronavirus policy.")]
        public void TerminateTravel()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.Travel);

            Travel travel = new Travel(Driver);
            string policyNumber = travel.FillOutPolicyDataAndIssuePolicy();

            travel.ChangePolicyStatus(policyNumber);

            var searchPolicyPage = webIMSHomePage.MenuBar.GoToSearchPolicyPage();
            searchPolicyPage.SearchPolicyAndOpen(policyNumber);

            travel.TerminatePolicy();
        }
        [TestMethod]
        public void TerminateRetailCaso()
        {
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.GoTo();
            var webIMSHomePage = signInPage.SignIn();
            webIMSHomePage.MenuBar.SelectProductFromProductList(ProductsLOB.RetailCaso);

            RetailCasco retailCasco = new RetailCasco(Driver);
            string policyNumber = retailCasco.FillOutPolicyDataAndIssuePolicy();

            retailCasco.ChangePolicyStatus(policyNumber);

            var searchPolicyPage = webIMSHomePage.MenuBar.GoToSearchPolicyPage();
            searchPolicyPage.SearchPolicyAndOpen(policyNumber);

            retailCasco.TerminatePolicy();
        }
    }
}
