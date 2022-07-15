using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Resources.DB;
using Resources.Functions;
using Resources.Models;
using Resources.Reporter;
using System;
using System.Threading;
using WebIMS.Models;

namespace WebIMS.Pages.ProductsPages
{
    public class ValuntaryHealth : BaseProductPage
    {
        public ValuntaryHealth(IWebDriver driver) : base(driver) { }

        #region Elements

        private IWebElement Terapist => Driver.FindElement(By.Id("Therapist_TherapistSelected"));
        private IWebElement Endocrinology => Driver.FindElement(By.Id("Endocrinology_EndocrinologySelected"));
        private IWebElement Cardiology => Driver.FindElement(By.Id("Cardiology_CardiologySelected"));
        private IWebElement Oncology => Driver.FindElement(By.Id("Oncology_OncologySelected"));
        private IWebElement CalculatePremium => Driver.FindElement(By.Id("calculateButton"));
        private IWebElement PremiumCalculatedAmount => Driver.FindElement(By.Id("PolicyDiscount_PremiumCalculated"));

        #endregion

        #region Methods

        public string FillOutPolicyDataAndIssuePolicy()
        {
            ValuntaryHealthModel valuntaryHealthModel = new ValuntaryHealthModel
            {
                InsuredPinCode = "11W2E5J",
                InsuredIdNumberPrefix = "AZE",
                InsuredIdNumber = "09329478",
                InsuredPhoneNumber = "994557455097",
                InsuredEmail = "mahdi.guliyev@ateshgah.com"
            };

            InsuredPinCode.SendKeys(valuntaryHealthModel.InsuredPinCode);
            InsuredIdNumberPrefix.SendKeys(valuntaryHealthModel.InsuredIdNumberPrefix);
            InsuredIdNumber.SendKeys(valuntaryHealthModel.InsuredIdNumber);
            SearchInsurer.Click();
            InsurePhoneNumber.SendKeys(valuntaryHealthModel.InsuredPhoneNumber);
            InsuredEmailAddress.SendKeys(valuntaryHealthModel.InsuredEmail);

            Actions actions = new Actions(Driver);
            actions.MoveToElement(AgenBroker);
            AgenBroker.Click();
            AgenBrokerItem.Click();
            Terapist.Click();
            Oncology.Click();
            CalculatePremium.Click();
            WaitUntilValueIsEqual(By.Id("PolicyDiscount_PremiumCalculated"), Convert.ToString(180));

            IssuePolicy.Click();

            bool isIssued = PageMessageBox.Text.Contains("Polis ilkin buraxılıb");
            string policyNumber = Driver.FindElement(By.Id("M_qavil__n_mr_si")).Text;
            if (!isIssued)
            {
                Report.LogTestStepForBugLogger(Status.Fail, "ValuntaryHealth cannot be issued");
                Assert.IsTrue(isIssued);

            }

            Report.LogPassingTestStepForBugLogger("ValuntaryHealth issued");
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
        public override void TerminatePolicy()
        {
            TerminateButton.Click();
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
