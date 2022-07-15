using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Resources.DB;
using Resources.Functions;
using Resources.Models;
using Resources.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebIMS.Models;

namespace WebIMS.Pages.ProductsPages
{
    public class VoluntaryPropertyLiability : BaseProductPage
    {
        public VoluntaryPropertyLiability(IWebDriver driver) : base(driver) { }

        #region Elements

        private IWebElement RegistrationNumber => Driver.FindElement(By.Id("Property_RegistrationNumber"));
        private IWebElement GrossArea => Driver.FindElement(By.Id("Property_GrossArea"));
        private IWebElement MarketValue => Driver.FindElement(By.Id("Property_MarketValue"));
        private IWebElement FullAddress => Driver.FindElement(By.Id("Property_FullAddress"));
        private IWebElement City => Driver.FindElement(By.Id("Property_CityText"));
        private IWebElement BakuCity => Driver.FindElement(By.XPath("//li/a[contains(text(), 'Bakı')]"));
        private IWebElement CoveragesRiskAmountGroup2 => Driver.FindElement(By.Id("Coverages_RiskAmountGroup2"));

        #endregion

        #region Methods
        public string FillOutPolicyDataAndIssuePolicy()
        {
            string registrationNumber = StaticMethods.GenerateRandomString(10);
            var voluntaryPropertyLiability = new VoluntaryPropertyLiabilityModel
            {
                InsuredPinCode = "69wyzmc",
                InsuredIdNumberPrefix = "AZE",
                InsuredIdNumber = "16288908",
                InsuredPhoneNumber = "994557455097",
                InsuredEmail = "mahdi.guliyev@ateshgah.com",
                RegistrationNumber = registrationNumber,
                GrossArea = "120",
                MarketValue = "120000",
                FullAddress = "TEST ADDRESS",
            };

            Actions actions = new Actions(Driver);

            RegistrationNumber.SendKeys(voluntaryPropertyLiability.RegistrationNumber);
            GrossArea.SendKeys(voluntaryPropertyLiability.GrossArea);
            MarketValue.SendKeys(voluntaryPropertyLiability.MarketValue);
            FullAddress.SendKeys(voluntaryPropertyLiability.FullAddress);
            actions.MoveToElement(City);
            City.Click();
            BakuCity.Click();

            InsuredPinCode.SendKeys(voluntaryPropertyLiability.InsuredPinCode);
            InsuredIdNumberPrefix.SendKeys(voluntaryPropertyLiability.InsuredIdNumberPrefix);
            InsuredIdNumber.SendKeys(voluntaryPropertyLiability.InsuredIdNumber);
            SearchInsurer.Click();
            InsurePhoneNumber.SendKeys(voluntaryPropertyLiability.InsuredPhoneNumber);
            InsuredEmailAddress.SendKeys(voluntaryPropertyLiability.InsuredEmail);

            
            actions.MoveToElement(AgenBroker);
            AgenBroker.Click();
            AgenBrokerItem.Click();
            CoveragesRiskAmountGroup2.Click();

            IssuePolicy.Click();

            bool isIssued = PageMessageBox.Text.Contains("Polis ilkin buraxılıb");
            string policyNumber = Driver.FindElement(By.Id("M_qavil__n_mr_si")).Text;
            if (!isIssued)
            {
                Report.LogTestStepForBugLogger(Status.Fail, "VoluntaryPropertyLiability cannot be issued");
                Assert.IsTrue(isIssued);

            }

            Report.LogPassingTestStepForBugLogger("VoluntaryPropertyLiability issued");
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
                            delete from [EAGLE].[Property].[Property] where object_guid=@objectGuid
                            delete from [EAGLE].[Property].[Coverage] where object_guid=@objectGuid
                            delete from [EAGLE].[Policies].[ObjectCoverage] where object_guid=@objectGuid
                            delete from [EAGLE].[Policies].[InsuredObject] where policy_action_guid=@policyActionGuid 
                            delete from [EAGLE].[Financials].[Installment] where policy_action_guid=@policyActionGuid
                            delete from [EAGLE].[Policies].[AcibisPolicyAction] where policy_action_guid=@policyActionGuid
                            delete from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid 
                            delete from [EAGLE].[Policies].[Policy] where policy_number=@policyNumber";
            QueryResultModel result = MSSQL.GetQueryResult(ConnectionStrings.EAGLE_TEST4, query);

            if (result.Error != null)
                Report.LogTestStepForBugLogger(Status.Fail, result.Error);

            return result;
        }
        #endregion
    }
}
