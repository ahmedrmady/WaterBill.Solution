using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterBill.SAL.Helpers
{
    public class WaterBillServicePrams
    {

        public string SubscriptionNo { get; set; }
        public decimal CurrentReadingMeter { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal TaxValue { get; set; }

    }
}
