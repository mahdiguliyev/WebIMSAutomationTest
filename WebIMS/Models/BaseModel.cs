using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebIMS.Models
{
    public class BaseModel
    {
        public string InsuredPinCode { get; set; }
        public string InsuredIdNumber { get; set; }
        public string InsuredIdNumberPrefix { get; set; }
        public string InsuredEmail { get; set; }
        public string InsuredPhoneNumber { get; set; }
    }
}
