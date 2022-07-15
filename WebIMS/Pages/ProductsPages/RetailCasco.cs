using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Resources.DB;
using Resources.Functions;
using Resources.Models;
using Resources.Reporter;
using WebIMS.Models;

namespace WebIMS.Pages.ProductsPages
{
    public class RetailCasco : BaseProductPage
    {
        public RetailCasco(IWebDriver driver) : base(driver) { }

        #region Elements
        private IWebElement VehicleRegNumber => Driver.FindElement(By.Id("Vehicle_RegNr"));
        private IWebElement VehicleRegCertNumber => Driver.FindElement(By.Id("Vehicle_RegCertNumber"));
        private IWebElement VehicleVehBrandOidText => Driver.FindElement(By.Id("Vehicle_VehBrandOidText"));
        private IWebElement VehicleVehModelOidText => Driver.FindElement(By.Id("Vehicle_VehModelOidText"));
        private IWebElement VehicleVehSubModelNameText => Driver.FindElement(By.Id("Vehicle_VehSubModelNameText"));
        private IWebElement VehicleManufactoryYear => Driver.FindElement(By.Id("Vehicle_ManufactoryYear"));
        private IWebElement RetailCascoObjectDeductibleText => Driver.FindElement(By.Id("RetailCascoObject_DeductibleText"));
        private IWebElement InsuredPersonSection => Driver.FindElement(By.XPath("//span[(contains(text(), 'Sığortalı'))]"));

        public IWebElement CalculatePremiumInsuredButton => WaitUntilElementIsClickable(By.XPath("//a[@id='calculateButton']"));
        private IWebElement Issue => WaitUntilElementIsClickable(By.Name("Issue"));

        #endregion

        public string FillOutPolicyDataAndIssuePolicy()
        {
            string vehicleRegNumber = StaticMethods.GenerateVehicleRegNumber();
            int vehicleRegCertNumber = StaticMethods.GenerateVehicleRegCertNumber();

            var retailCascoModel = new RetailCasoModel
            {
                
                InsuredPinCode = "58N89NU",
                InsuredIdNumberPrefix = "AA",
                InsuredIdNumber = "3398850",
                InsuredPhoneNumber = "994557455097",
                InsuredEmail = "mahdi.guliyev@ateshgah.com",
                VehicleRegNumber = vehicleRegNumber,
                VehicleRegCertNumber = vehicleRegCertNumber.ToString(),
                VehicleVehBrandOidText = "AUDI",
                VehicleVehModelOidText = "A3",
                VehicleVehSubModelNameText = "A3 (1.8)",
                VehicleManufactoryYear = "2015",
                RetailCascoObjectDeductibleText = "200"
            };

            VehicleRegNumber.SendKeys(retailCascoModel.VehicleRegNumber);
            VehicleRegCertNumber.SendKeys(retailCascoModel.VehicleRegCertNumber);
            VehicleVehBrandOidText.SendKeys(retailCascoModel.VehicleVehBrandOidText);
            VehicleVehModelOidText.SendKeys(retailCascoModel.VehicleVehModelOidText);
            VehicleVehSubModelNameText.SendKeys(retailCascoModel.VehicleVehSubModelNameText);
            VehicleManufactoryYear.SendKeys(retailCascoModel.VehicleManufactoryYear);
            RetailCascoObjectDeductibleText.SendKeys(retailCascoModel.RetailCascoObjectDeductibleText);

            InsuredPersonSection.Click();

            InsuredPinCode.SendKeys(retailCascoModel.InsuredPinCode);
            InsuredIdNumberPrefix.SendKeys(retailCascoModel.InsuredIdNumberPrefix);
            InsuredIdNumber.SendKeys(retailCascoModel.InsuredIdNumber);
            SearchInsurer.Click();
            InsurePhoneNumber.SendKeys(retailCascoModel.InsuredPhoneNumber);
            InsuredEmailAddress.SendKeys(retailCascoModel.InsuredEmail);

            CalculatePremiumInsuredButton.Click();

            Issue.Click();

            bool isIssued = WaitAndFindElement(By.Id("PageMessageBox")).Text.Contains("Müqavilə uğurla buraxılıb");
            string policyNumber = Driver.FindElement(By.Id("M_qavil__n_mr_si")).Text;
            if (!isIssued)
            {
                Report.LogTestStepForBugLogger(Status.Fail, "RetailCaso cannot be issued");
                Assert.IsTrue(isIssued);

            }

            Report.LogPassingTestStepForBugLogger("RetailCaso issued");
            Assert.IsTrue(isIssued);
            return policyNumber;
        }

        public override QueryResultModel RemovePolicyFromDatabase(string policyNumber)
        {
            var query = $@"
						declare @policyNumber nvarchar(50) = '{policyNumber}'
                        declare @policyGuid nvarchar(50) = (select policy_guid from [EAGLE].[Policies].[Policy] where policy_number= @policyNumber)

                        delete from [EAGLE].[Policies].[InsuredRisk] where object_guid in (
	                        select object_guid from [EAGLE].[Policies].[InsuredObject] where policy_action_guid in (
		                        select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid
                        ))

                        delete from [EAGLE].[MOD].[VehicleSurveyAct] where policy_action_guid in (
		                        select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid
                        )

                        delete from [EAGLE].[MOD].[CoverageRetailCascoVehicle] where object_guid in (
	                        select object_guid from [EAGLE].[Policies].[InsuredObject] where policy_action_guid in (
		                        select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid
                        ))

                        delete from [EAGLE].[MOD].[Vehicle] where object_guid in (
	                        select object_guid from [EAGLE].[Policies].[InsuredObject] where policy_action_guid in (
		                        select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid
                        ))

                        delete from [EAGLE].[MOD].[VehicleEquipment] where object_guid in (
	                        select object_guid from [EAGLE].[Policies].[InsuredObject] where policy_action_guid in (
		                        select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid
                        ))

                        delete from [EAGLE].[Property].[Property] where object_guid in (
	                        select object_guid from [EAGLE].[Policies].[InsuredObject] where policy_action_guid in (
		                        select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid
                        ))
                        delete from [EAGLE].[Property].[Coverage] where object_guid in (
	                        select object_guid from [EAGLE].[Policies].[InsuredObject] where policy_action_guid in (
		                        select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid
                        ))
                        delete from [EAGLE].[Policies].[ObjectCoverage] where object_guid in (
	                        select object_guid from [EAGLE].[Policies].[InsuredObject] where policy_action_guid in (
		                        select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid
                        ))

                        delete from [EAGLE].[Policies].[InsuredObject] where policy_action_guid in (
		                        select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid
                        )

                        delete from [EAGLE].[Financials].[Installment] where policy_action_guid in (
	                        select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid)

                        delete from [EAGLE].[Policies].[AcibisPolicyAction] where policy_action_guid in (
		                        select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid
                        )
                        delete from [EAGLE].[Policies].[PolicyAction] where policy_guid = @policyGuid
                        delete from [EAGLE].[Policies].[Policy] where policy_number=@policyNumber";

			QueryResultModel result = MSSQL.GetQueryResult(ConnectionStrings.EAGLE_TEST4, query);

			if (result.Error != null)
				Report.LogTestStepForBugLogger(Status.Fail, result.Error);

			return result;
		}
    }
}
