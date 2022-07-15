using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebIMS.Models
{
    public class AntiCoronavirusModel : BaseModel
    {
        public string BeneficiaryPinCode { get; set; }
        public string BeneficiaryIdNumber { get; set; }
        public string BeneficiaryIdNumberPrefix { get; set; }
        public string BeneficiaryEmail { get; set; }
        public string BeneficiaryPhoneNumber { get; set; }
    }
}
