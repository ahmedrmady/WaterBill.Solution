using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterBill.SAL.Helpers;

namespace WaterBill.SAL.Interfaces
{
    public interface IWaterBillService
    {
        public int GetSliceValueForUnits(int unitNo);

        public Task<WaterBillComponents> GetInvoiceTotalBillComponets(WaterBillServicePrams prams);
    }
}
