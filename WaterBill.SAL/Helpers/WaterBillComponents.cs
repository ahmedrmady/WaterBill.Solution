using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterBill.SAL.Helpers
{
    public class WaterBillComponents
    {
        public decimal InvoiceConsumptionValue { get; set; }

        public decimal InvoiceWastewaterConsumptionValue { get; set; }

        public decimal TotalInvoice { get; set; }

        public decimal TaxValue { get; set;}
        
        public decimal InvoicesTotalBill { get; set;}
    }
}
