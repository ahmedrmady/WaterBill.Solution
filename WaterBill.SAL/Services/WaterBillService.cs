using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterBill.BAL.Interfaces;
using WaterBill.DAL.Data.Entities;
using WaterBill.SAL.Helpers;
using WaterBill.SAL.Interfaces;

namespace WaterBill.SAL.Services
{
    public class WaterBillService : IWaterBillService
    {
        private const int defualtSliceValueCondtionPerUnit = 15;
        private readonly IUnitOfWork _unitOfWork;

        public WaterBillService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
      

        public async Task<WaterBillComponents> GetInvoiceTotalBillComponets(WaterBillServicePrams prams)
        {
            var totalBill = 0.0m;
            var waterBillComponents = new WaterBillComponents();

            waterBillComponents.TaxValue = prams.TaxValue;

            //get the subscription from db
            var subscription = await _unitOfWork.Repositry<Subscription>().GetAsync(prams.SubscriptionNo);
            if (subscription is null) return null;

            //get the slice Value For this number of Units  
            var sliceValueForUnits =  GetSliceValueForUnits(subscription.UnitNo);

            //get the current Consumption Amount (last reading - current reading)
            var currentConsumptionAmount = prams.CurrentReadingMeter - subscription.LastReadingMeter;

            //get the InvoiceConsumptionValue
            waterBillComponents.InvoiceConsumptionValue = await GetInvoiceConsumptionValue(currentConsumptionAmount, sliceValueForUnits);

            waterBillComponents.TotalInvoice += waterBillComponents.InvoiceConsumptionValue;

            // check if there is Sanitation ?
            if (subscription.IsThereSanitation)
            {
                waterBillComponents.InvoiceWastewaterConsumptionValue= waterBillComponents.InvoiceConsumptionValue / 2; // add 50% 
                waterBillComponents.TotalInvoice += waterBillComponents.InvoiceWastewaterConsumptionValue;
            }

            //add the service fee to the bill
           
            waterBillComponents.TotalInvoice += prams.ServiceFee;
            waterBillComponents.InvoicesTotalBill = waterBillComponents.TotalInvoice;

            // add the tax fee
            waterBillComponents.TaxValue = waterBillComponents.TotalInvoice * (prams.TaxValue / 100);
            waterBillComponents.InvoicesTotalBill += waterBillComponents.TaxValue;

            
            return waterBillComponents;

        }

        public int GetSliceValueForUnits(int unitNo)
        {

            return unitNo * defualtSliceValueCondtionPerUnit;
        }

        private async Task<decimal> GetInvoiceConsumptionValue ( decimal currentConsumptionAmount,int sliceValueForUnits)
        {
            //get the defualtslicevalues from db
            var defualtslicevalues = await _unitOfWork.Repositry<SliceValue>().GetAllAsync();

            var invoiceConsumptionValue = 0.0m;
            for (int i = 0; i < defualtslicevalues.Count; i++)
            {
                // if the amount is less then the sliceValueForUnits
                if (currentConsumptionAmount < sliceValueForUnits)
                {
                    invoiceConsumptionValue += currentConsumptionAmount * defualtslicevalues[i].WaterPrice;

                    break;
                }
                // if the amount is bigger then the sliceValueForUnits
                else if (currentConsumptionAmount >= sliceValueForUnits)
                {

                    currentConsumptionAmount -= sliceValueForUnits;

                    invoiceConsumptionValue += sliceValueForUnits * defualtslicevalues[i].WaterPrice;
                }
                //if no more Consumption break the loop
                if (currentConsumptionAmount == 0)
                    break;

                //if it's last slice
                if (i == defualtslicevalues.Count - 1 && currentConsumptionAmount != 0)
                    invoiceConsumptionValue += currentConsumptionAmount * defualtslicevalues[i].WaterPrice;

            }
            return invoiceConsumptionValue;
        }
    }
}
