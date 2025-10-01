using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBillingApp
{
    public class InsurancePolicy
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal BasePrice { get; set; }
        public int RiskFactor { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
