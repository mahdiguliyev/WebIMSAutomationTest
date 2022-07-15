using System;
using System.Collections.Generic;
using System.Text;

namespace Resources.Models
{
    public class PolicyKTSIssueModel
    {
        public string BrokerTaxId { get; set; }
        public string EndDate { get; set; }
        public InsuredPersonModel InsuredPerson { get; set; }
        public string Number { get; set; }
        public string PolicyActionGuid { get; set; }
        public string PolicyDate { get; set; }
        public decimal Premium { get; set; }
        public string ProductCode { get; set; }
        public int[] Programs { get; set; }
        public string SellerLogin { get; set; }
        public string Series { get; set; }
        public string StartDate { get; set; }
    }
}
