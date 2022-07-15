using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Resources.DB;
using Resources.Models;
using Resources.Reporter;
using System.Threading;
using WebIMS.Models;

namespace WebIMS.Pages.ProductsPages
{
    public class AntiCoronavirus : BaseProductPage
    {
        public AntiCoronavirus(IWebDriver driver) : base(driver) { }

        #region Elements

        private IWebElement BeneficiaryPinCode => Driver.FindElement(By.Id("Beneficiary_SearchParameters_PIN"));
        private IWebElement BeneficiaryIdNumberPrefix => Driver.FindElement(By.Id("Beneficiary_SearchParameters_IdSeries"));
        private IWebElement BeneficiaryIdNumber => Driver.FindElement(By.Id("Beneficiary_SearchParameters_IdNumber"));
        private IWebElement BeneficiaryPhoneNumber => WaitAndFindElement(By.Id("Beneficiary_Phone"));
        private IWebElement BeneficiaryEmailAddress => Driver.FindElement(By.Id("Beneficiary_Email"));
        private IWebElement SearchBeneficiary => Driver.FindElement(By.Id("Beneficiary_SearchParameters_Search"));
        private IWebElement CoveragesRiskAmountGroup2 => Driver.FindElement(By.Id("Coverages_RiskAmountGroup2"));
        private IWebElement SumInsured => Driver.FindElement(By.Id("SumInsured"));
        private IWebElement PolicyDiscount => Driver.FindElement(By.Id("PolicyDiscount_PremiumCalculated"));

        #endregion


        #region Methods

        public string FillOutPolicyDataAndIssuePolicy()
        {
            var antiCoronavirusModel = new AntiCoronavirusModel
            {
                InsuredPinCode = "69wyzmc",
                InsuredIdNumberPrefix = "AZE",
                InsuredIdNumber = "16288908",
                InsuredPhoneNumber = "994557455097",
                InsuredEmail = "mahdi.guliyev@ateshgah.com",
                BeneficiaryPinCode = "4Z6NNQZ",
                BeneficiaryIdNumberPrefix = "AZE",
                BeneficiaryIdNumber = "00121027",
                BeneficiaryPhoneNumber = "994557455097",
                BeneficiaryEmail = "vugar.shixaliyev@ateshgah.com",
            };
            InsuredPinCode.SendKeys(antiCoronavirusModel.InsuredPinCode);
            InsuredIdNumberPrefix.SendKeys(antiCoronavirusModel.InsuredIdNumberPrefix);
            InsuredIdNumber.SendKeys(antiCoronavirusModel.InsuredIdNumber);
            SearchInsurer.Click();
            InsurePhoneNumber.SendKeys(antiCoronavirusModel.InsuredPhoneNumber);
            InsuredEmailAddress.SendKeys(antiCoronavirusModel.InsuredEmail);

            BeneficiaryPinCode.SendKeys(antiCoronavirusModel.BeneficiaryPinCode);
            BeneficiaryIdNumberPrefix.SendKeys(antiCoronavirusModel.BeneficiaryIdNumberPrefix);
            BeneficiaryIdNumber.SendKeys(antiCoronavirusModel.BeneficiaryIdNumber);
            SearchBeneficiary.Click();
            BeneficiaryPhoneNumber.SendKeys(antiCoronavirusModel.BeneficiaryPhoneNumber);
            BeneficiaryEmailAddress.SendKeys(antiCoronavirusModel.BeneficiaryEmail);

            Actions actions = new Actions(Driver);
            actions.MoveToElement(AgenBroker);    
            AgenBroker.Click();
            AgenBrokerItem.Click();
            CoveragesRiskAmountGroup2.Click();

            IssuePolicy.Click();

            bool isIssued = WaitAndFindElement(By.Id("PageMessageBox")).Text.Contains("Polis ilkin buraxılıb");
            string policyNumber = Driver.FindElement(By.Id("M_qavil__n_mr_si")).Text;
            if (!isIssued)
            {
                //RemovePolicyFromDB(PolicyNumber.Text);
                Report.LogTestStepForBugLogger(Status.Fail, "AntiCoronavirus cannot be issued");
                Assert.IsTrue(isIssued);

            }

            Report.LogPassingTestStepForBugLogger("AntiCoronavirus issued");
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
        //public void CancelPolicy()
        //{
        //    CancelButton.Click();
        //    CalcelPolicyModalFormCalcelButton.Click();
        //    Thread.Sleep(500);
        //    bool isCanceled = WaitAndFindElement(By.Id("PageMessageBox")).Text.Contains("Polis ləğv edildi");
        //    if (!isCanceled)
        //    {
        //        Report.LogTestStepForBugLogger(Status.Fail, "AntiCoronavirus policy cannot be canceled");
        //        Assert.IsTrue(isCanceled);
        //    }
        //    else
        //    {
        //        CheckPolicyStatus(PolicyNumber.Text, "İmtina olunub");
        //        Report.LogTestStepForBugLogger(Status.Pass, "AntiCoronavirus policy is canceled");
        //        Assert.IsTrue(isCanceled);
        //    }
        //}
        //public void CheckPolicyStatus(string policyNumber, string status)
        //{
        //    //SearchPolicyPage searchPolicyPage = new SearchPolicyPage(Driver);
        //    //searchPolicyPage.SearchPolicyAndOpen(policyNumber);
        //    if (PolicyStatus.Text != status)
        //    {
        //        Report.LogTestStepForBugLogger(Status.Fail, $"Policy status is not '{status}', current status is '{PolicyStatus.Text}'");
        //    }
        //    else if (PolicyStatus.Text == status)
        //    {
        //        Report.LogTestStepForBugLogger(Status.Pass, $"Policy status is '{status}'");
        //    }
        //    else
        //    {
        //        Report.LogTestStepForBugLogger(Status.Warning, $"Policy status is not defined");
        //    }
        //}
        #endregion
    }
}
