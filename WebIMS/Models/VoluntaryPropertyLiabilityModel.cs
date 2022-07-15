using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebIMS.Models
{
    public class VoluntaryPropertyLiabilityModel : BaseModel
    {
        public string RegistrationNumber { get; set; }
        public string GrossArea { get; set; }
        public string MarketValue { get; set; }
        public string FullAddress { get; set; }
    }
}
