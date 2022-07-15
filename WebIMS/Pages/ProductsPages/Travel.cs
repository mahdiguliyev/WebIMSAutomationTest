using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Resources.DB;
using Resources.Models;
using Resources.Reporter;
using System;
using System.Threading;
using WebIMS.Models;

namespace WebIMS.Pages.ProductsPages
{
    public class Travel : BaseProductPage
    {
        public Travel(IWebDriver driver) : base(driver) { }

        #region Elements

        private IWebElement TerritoryOid => Driver.FindElement(By.Id("Group_TerritoryOidText"));
        private IWebElement TerritoryOption => Driver.FindElement(By.XPath("//li/a[contains(text(), 'Türkiyə')]"));
        private IWebElement EmbassyOid => Driver.FindElement(By.Id("Group_EmbassyOidText"));
        private IWebElement EmbassyOption => Driver.FindElement(By.XPath("//li/a[contains(text(), 'Germany')]"));
        private IWebElement PassportNr => Driver.FindElement(By.Id("Travellers_0__PassportNr"));
        private IWebElement Name => Driver.FindElement(By.Id("Travellers_0__Name"));
        private IWebElement Surname => Driver.FindElement(By.Id("Travellers_0__Surname"));
        private IWebElement BirthDate => Driver.FindElement(By.Id("Travellers_0__BirthDate"));
        private IWebElement IsPolicyHolder => Driver.FindElement(By.Id("Travellers_0__IsPolicyHolder"));
        private IWebElement FindAnotherClient => Driver.FindElement(By.Id("Client_FindAnother"));
        private IWebElement IdentificationType => Driver.FindElement(By.Id("Client_SearchParameters_IdentificationTypeText"));
        private IWebElement IdentificationTypeOption => WaitAndFindElement(By.XPath("//a[contains(text(),'Şəxsiyyət vəsiqəsi')]"));
        private IWebElement CalculatePremium => Driver.FindElement(By.Id("calculateButton"));
        private IWebElement Notes => WaitAndFindElement(By.Id("AnulationNotes"));
        private IWebElement CalculateTerminationAmount => WaitAndFindElement(By.Id("CalculateTerminationAmountBtn"));

        #endregion

        #region Methods

        public string FillOutPolicyDataAndIssuePolicy()
        {
            var travel = new TravelModel
            {
                InsuredPinCode = "69wyzmc",
                InsuredIdNumberPrefix = "AZE",
                InsuredIdNumber = "16288908",
                InsuredPhoneNumber = "994557455097",
                InsuredEmail = "mahdi.guliyev@ateshgah.com",
                PassportNumber = "C02749231",
                TravellerName = "Mahdi",
                TravellerSurname = "Guliyev",
                TravellerDateOfBirth = "28.10.1997"
            };

            Actions actions = new Actions(Driver);
            TerritoryOid.Click();
            TerritoryOption.Click();
            EmbassyOid.Click();
            EmbassyOption.Click();

            PassportNr.SendKeys(travel.PassportNumber);
            Name.SendKeys(travel.TravellerName);
            Surname.SendKeys(travel.TravellerSurname);
            IsPolicyHolder.Click();
            Thread.Sleep(500);
            BirthDate.Click();
            BirthDate.SendKeys(travel.TravellerDateOfBirth);

            FindAnotherClient.Click();
            actions.MoveToElement(CalculatePremium);
            actions.Perform();
            IdentificationType.Click();
            IdentificationTypeOption.Click();
            InsuredPinCode.SendKeys(travel.InsuredPinCode);
            InsuredIdNumberPrefix.SendKeys(travel.InsuredIdNumberPrefix);
            InsuredIdNumber.SendKeys(travel.InsuredIdNumber);
            SearchInsurer.Click();
            InsurePhoneNumber.SendKeys(travel.InsuredPhoneNumber);
            InsuredEmailAddress.SendKeys(travel.InsuredEmail);

            CalculatePremium.Click();
            WaitUntilValueIsEqual(By.Id("PolicyDiscount_PremiumCalculated"), Convert.ToString(7));

            IssuePolicy.Click();

            bool isIssued = PageMessageBox.Text.Contains("Polis ilkin buraxılıb");
            string policyNumber = Driver.FindElement(By.Id("M_qavil__n_mr_si")).Text;
            if (!isIssued)
            {
                Report.LogTestStepForBugLogger(Status.Fail, "Travel cannot be issued");
                Assert.IsTrue(isIssued);

            }

            Report.LogPassingTestStepForBugLogger("Travel issued");
            Assert.IsTrue(isIssued);

            return policyNumber;
        }
        public QueryResultModel RemovePolicyFromDB(string policyNumber)
        {
            string query = $@"declare @policyNumber nvarchar(50) = '{policyNumber}'
                            declare @policyGuid nvarchar(50) = ( select policy_guid from [EAGLE].[Policies].[Policy] where policy_number= @policyNumber )
                            declare @policyActionGuid  nvarchar(50) = (select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid = @policyGuid)
                            declare @objectGuid nvarchar(50) = (select object_guid from [EAGLE].[Policies].[InsuredObject] where policy_action_guid= @policyActionGuid)

                            delete from [EAGLE].[Policies].[InsuredRisk] where object_guid=@objectGuid
                            delete from [EAGLE].[Policies].[ObjectCoverage] where object_guid=@objectGuid
                            delete from [EAGLE].[Policies].[InsuredObject] where policy_action_guid=@policyActionGuid 
                            delete from [EAGLE].[Financials].[Installment] where policy_action_guid=@policyActionGuid
                            delete from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid 
                            delete from [EAGLE].[Policies].[Policy] where policy_number=@policyNumber";
            QueryResultModel result = MSSQL.GetQueryResult(ConnectionStrings.EAGLE_TEST4, query);

            if (result.Error != null)
                Report.LogTestStepForBugLogger(Status.Fail, result.Error);

            return result;
        }
        public override void CancelPolicy()
        {
            CancelButton.Click();
            CalcelPolicyModalFormCalcelButton.Click();
            Notes.SendKeys("Test note entered for testing cancel operation");
            CalcelPolicyModalFormCalcelButton.Click();
            Thread.Sleep(500);
            bool isCanceled = WaitAndFindElement(By.Id("PageMessageBox")).Text.Contains("Polis ləğv edildi");
            if (!isCanceled)
            {
                Report.LogTestStepForBugLogger(Status.Fail, "Policy cannot be canceled");
                Assert.IsTrue(isCanceled);
            }
            else
            {
                CheckPolicyStatus(PolicyNumber.Text, "İmtina olunub");
                Report.LogTestStepForBugLogger(Status.Pass, "Policy is canceled");
                Assert.IsTrue(isCanceled);
            }
        }
        public override void TerminatePolicy()
        {
            TerminateButton.Click();
            CalculateTerminationAmount.Click();
            Thread.Sleep(500);
            TerminatePolicyModalFormCalcelButton.Click();
            Thread.Sleep(500);
            bool isTerminated = WaitAndFindElement(By.Id("PageMessageBox")).Text.Contains("Polisə xitam verilib");
            if (!isTerminated)
            {
                Report.LogTestStepForBugLogger(Status.Fail, "Policy cannot be terminated");
                Assert.IsTrue(isTerminated);
            }
            else
            {
                Report.LogTestStepForBugLogger(Status.Pass, "Policy is terminated");
                Assert.IsTrue(isTerminated);
            }
        }
        #endregion
    }
}
