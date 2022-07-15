namespace WebIMS.Models
{
    public class CascoCombiModel : BaseModel
    {
        public string BeneficiaryPinCode { get; set; }
        public string BeneficiaryIdNumber { get; set; }
        public string BeneficiaryIdNumberPrefix { get; set; }
        public string BeneficiaryEmail { get; set; }
        public string BeneficiaryPhoneNumber { get; set; }

        public string VehicleRegNumber { get; set; }
        public string VehicleRegCertNumber { get; set; }
        public string VehicleVehBrandOidText { get; set; }
        public string VehicleVehModelOidText { get; set; }
        public string VehicleVehSubModelNameText { get; set; }
        public string VehicleManufactoryYear { get; set; }
        public string VehicleDetailsVin { get; set; }
        public string VehicleDetailsBodyNumber { get; set; }
        public string VehicleDetailsEngine { get; set; }
        public string VehicleDetailsVehTypeOidText { get; set; }
        public string VehicleDetailsOwnerShipOidText { get; set; }
        public string VehicleDetailsUsageOidText { get; set; }
        public string VehicleDetailsEngineCapacity { get; set; }
        public string VehicleDetailsRegTerritoryOidText { get; set; }
        public string VehicleDetailsNumberOfSeats { get; set; }
        public string VehicleDetailsNumberOfKeys { get; set; }
        public string VehicleDetailsRealPrice { get; set; }
        public string VehicleDetailsInsuredSum { get; set; }

        public string RetailCascoObjectDeductibleText { get; set; }
    }
}
