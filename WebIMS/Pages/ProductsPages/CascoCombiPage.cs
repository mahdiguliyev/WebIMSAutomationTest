using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Resources.Functions;
using Resources.Reporter;
using WebIMS.Models;

namespace WebIMS.Pages.ProductsPages
{
    public class CascoCombiPage : BaseProductPage
    {
        public CascoCombiPage(IWebDriver driver) : base(driver) { }

        #region Elements

        private IWebElement BeneficiarySearchParametersPIN => Driver.FindElement(By.Id("Beneficiary_SearchParameters_PIN"));
        private IWebElement BeneficiarySearchParametersIdSeries => Driver.FindElement(By.Id("Beneficiary_SearchParameters_IdSeries"));
        private IWebElement BeneficiarySearchParametersIdNumber => Driver.FindElement(By.Id("Beneficiary_SearchParameters_IdNumber"));
        private IWebElement SearchBeneficiary => Driver.FindElement(By.Id("Beneficiary_SearchParameters_Search"));
        private IWebElement BeneficiaryPhone => WaitAndFindElement(By.Id("Beneficiary_Phone"));
        private IWebElement BeneficiaryEmail => Driver.FindElement(By.Id("Beneficiary_Email"));
        private IWebElement AddNewVehicle => Driver.FindElement(By.XPath("//span[contains(text(), 'Nəqliyyat vasitəsi əlavə et')]"));
        private IWebElement InsuredObjectListCell => WaitAndFindElement(By.XPath("//td[@title='KASKO']"));

        private IWebElement ObjectDetailsRegNr => WaitAndFindElement(By.Id("ObjectDetails_RegNr"));
        private IWebElement ObjectDetailsRegCertNumber => Driver.FindElement(By.Id("ObjectDetails_RegCertNumber"));
        private IWebElement ObjectDetailsVin => Driver.FindElement(By.Id("ObjectDetails_Vin"));
        private IWebElement ObjectDetailsBodyNumber => Driver.FindElement(By.Id("ObjectDetails_BodyNumber"));
        private IWebElement ObjectDetailsEngine => Driver.FindElement(By.Id("ObjectDetails_Engine"));
        private IWebElement ObjectDetailsVehTypeOidText => Driver.FindElement(By.Id("ObjectDetails_VehTypeOidText"));
        private IWebElement ObjectDetailsOwnerShipOidText => Driver.FindElement(By.Id("ObjectDetails_OwnerShipOidText"));
        private IWebElement ObjectDetailsUsageOidText => Driver.FindElement(By.Id("ObjectDetails_UsageOidText"));
        private IWebElement ObjectDetailsManufactoryYear => Driver.FindElement(By.Id("ObjectDetails_ManufactoryYear"));
        private IWebElement ObjectDetailsVehBrandOidText => Driver.FindElement(By.Id("ObjectDetails_VehBrandOidText"));
        private IWebElement ObjectDetailsVehModelOidText => Driver.FindElement(By.Id("ObjectDetails_VehModelOidText"));
        private IWebElement ObjectDetailsVehSubModelOidText => Driver.FindElement(By.Id("ObjectDetails_VehSubModelOidText"));
        private IWebElement ObjectDetailsEngineCapacity => Driver.FindElement(By.Id("ObjectDetails_EngineCapacity"));
        private IWebElement ObjectDetailsRegTerritoryOidText => Driver.FindElement(By.Id("ObjectDetails_RegTerritoryOidText"));
        private IWebElement ObjectDetailsNumberOfSeats => Driver.FindElement(By.Id("ObjectDetails_NumberOfSeats"));
        private IWebElement ObjectDetailsNumberOfKeys => Driver.FindElement(By.Id("ObjectDetails_NumberOfKeys"));
        private IWebElement ObjectDetailsRealPrice => Driver.FindElement(By.Id("ObjectDetails_RealPrice"));
        private IWebElement ObjectDetailsInsuredSum => Driver.FindElement(By.Id("ObjectDetails_InsuredSum"));
        private IWebElement ObjectDetailsDeductibleIdText => WaitAndFindElement(By.Id("ObjectDetails_DeductibleIdText"));
        private IWebElement CalculatePremiumInsuredButton => WaitUntilElementIsClickable(By.XPath("//a[@id='calculateButton']"));
        private IWebElement Issue => WaitUntilElementIsClickable(By.Name("Issue"));

        #endregion

        public string FillOutPolicyDataAndIssuePolicy()
        {
            string vehicleRegNumber = StaticMethods.GenerateVehicleRegNumber();
            int vehicleRegCertNumber = StaticMethods.GenerateVehicleRegCertNumber();
            string vehicleVinNumber = StaticMethods.GenerateVehicleVinNumber();
            string vehicleBodyNumber = StaticMethods.GenerateVehicleBodyNumber();
            string vehicleEngineNumber = StaticMethods.GenerateVehicleBodyNumber();

            var cascoCombiModel = new CascoCombiModel
            {

                InsuredPinCode = "58N89NU",
                InsuredIdNumberPrefix = "AA",
                InsuredIdNumber = "3398850",
                InsuredPhoneNumber = "994557455097",
                InsuredEmail = "mahdi.guliyev@ateshgah.com",

                BeneficiaryPinCode = "4Z6NNQZ",
                BeneficiaryIdNumberPrefix = "AZE",
                BeneficiaryIdNumber = "00121027",
                BeneficiaryPhoneNumber = "994557455097",
                BeneficiaryEmail = "mahdi.guliyev@ateshgah.com",

                VehicleRegNumber = vehicleRegNumber,
                VehicleRegCertNumber = vehicleRegCertNumber.ToString(),
                VehicleVehBrandOidText = "AUDI",
                VehicleVehModelOidText = "A3",
                VehicleVehSubModelNameText = "Heçbek, 2000-2003, 1,600-2,000",
                VehicleManufactoryYear = "2015",
                VehicleDetailsVin = vehicleVinNumber,
                VehicleDetailsBodyNumber = vehicleBodyNumber,
                VehicleDetailsEngine = vehicleEngineNumber,
                VehicleDetailsVehTypeOidText = "Şəxsi minik avtomobilləri",
                VehicleDetailsOwnerShipOidText = "Avtomobilin sahibi",
                VehicleDetailsUsageOidText = "Şəxsi (minik avtomobili)",
                VehicleDetailsEngineCapacity = "205",
                VehicleDetailsRegTerritoryOidText = "Bakı",
                VehicleDetailsNumberOfSeats = "4",
                VehicleDetailsNumberOfKeys = "1",
                VehicleDetailsRealPrice = "25000",
                VehicleDetailsInsuredSum = "2500",

                RetailCascoObjectDeductibleText = "200"
            };

            InsuredPinCode.SendKeys(cascoCombiModel.InsuredPinCode);
            InsuredIdNumberPrefix.SendKeys(cascoCombiModel.InsuredIdNumberPrefix);
            InsuredIdNumber.SendKeys(cascoCombiModel.InsuredIdNumber);
            SearchInsurer.Click();
            InsurePhoneNumber.SendKeys(cascoCombiModel.InsuredPhoneNumber);
            InsuredEmailAddress.SendKeys(cascoCombiModel.InsuredEmail);

            BeneficiarySearchParametersPIN.SendKeys(cascoCombiModel.BeneficiaryPinCode);
            BeneficiarySearchParametersIdSeries.SendKeys(cascoCombiModel.BeneficiaryIdNumberPrefix);
            BeneficiarySearchParametersIdNumber.SendKeys(cascoCombiModel.BeneficiaryIdNumber);
            SearchBeneficiary.Click();
            BeneficiaryPhone.SendKeys(cascoCombiModel.BeneficiaryPhoneNumber);
            BeneficiaryEmail.SendKeys(cascoCombiModel.BeneficiaryEmail);

            AddNewVehicle.Click();

            ObjectDetailsRegNr.SendKeys(cascoCombiModel.VehicleRegNumber);
            ObjectDetailsRegCertNumber.SendKeys(cascoCombiModel.VehicleRegCertNumber);
            ObjectDetailsVin.SendKeys(cascoCombiModel.VehicleDetailsVin);
            ObjectDetailsBodyNumber.SendKeys(cascoCombiModel.VehicleDetailsBodyNumber);
            ObjectDetailsEngine.SendKeys(cascoCombiModel.VehicleDetailsEngine);
            ObjectDetailsVehTypeOidText.SendKeys(cascoCombiModel.VehicleDetailsVehTypeOidText);
            ObjectDetailsOwnerShipOidText.SendKeys(cascoCombiModel.VehicleDetailsOwnerShipOidText);
            ObjectDetailsUsageOidText.SendKeys(cascoCombiModel.VehicleDetailsUsageOidText);
            ObjectDetailsManufactoryYear.SendKeys(cascoCombiModel.VehicleManufactoryYear);
            ObjectDetailsVehBrandOidText.SendKeys(cascoCombiModel.VehicleVehBrandOidText);
            ObjectDetailsVehModelOidText.SendKeys(cascoCombiModel.VehicleVehModelOidText);
            ObjectDetailsVehSubModelOidText.SendKeys(cascoCombiModel.VehicleVehSubModelNameText);
            ObjectDetailsEngineCapacity.SendKeys(cascoCombiModel.VehicleDetailsEngineCapacity);
            ObjectDetailsRegTerritoryOidText.SendKeys(cascoCombiModel.VehicleDetailsRegTerritoryOidText);
            ObjectDetailsNumberOfSeats.SendKeys(cascoCombiModel.VehicleDetailsNumberOfSeats);
            ObjectDetailsNumberOfKeys.SendKeys(cascoCombiModel.VehicleDetailsNumberOfKeys);
            ObjectDetailsRealPrice.SendKeys(cascoCombiModel.VehicleDetailsRealPrice);
            ObjectDetailsInsuredSum.SendKeys(cascoCombiModel.VehicleDetailsInsuredSum);

            InsuredObjectListCell.Click();
            InsuredObjectListCell.Click();
            ObjectDetailsDeductibleIdText.Click();
            WaitAndFindElement(By.XPath("//a[contains(text(), '200')]")).Click();
            //ObjectDetailsDeductibleIdText.Clear();
            //ObjectDetailsDeductibleIdText.SendKeys(cascoCombiModel.RetailCascoObjectDeductibleText);
            AgenBroker.SendKeys("\"Atəşgah\" Sığorta Agentliyi  MMC");

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
    }
}
