using System.ComponentModel.DataAnnotations;
using WaterBill.DAL.Data.Entities;

namespace WaterBill.PL.ViewModels
{
    public class InvoiceDto
    {

        [Required]
        public string Id { get; set; }
        public string Year { get; set; }

        public string RrealEstateTypeCode { get; set; } 

        public string SubscriptionId { get; set; }      

        public string SubscriberId { get; set; }          

        public DateTime Date { get; set; }
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int PreviousConsumptionAmount { get; set; }
        public int CurrentConsumptionAmount { get; set; }
        public int AmountConsumption { get; set; }

        public decimal ServiceFee { get; set; }
        public decimal TaxRate { get; set; }

        public bool IsThereSanitation { get; set; }

        public decimal ConsumptionValue { get; set; }
        public decimal WastewaterConsumptionValue { get; set; }

        public decimal TaxValue { get; set; }
        public decimal TotalBill { get; set; }

        public decimal TotalInvoice { get; set; }

        public int UnitNo { get; set; }

        public string SubscriberName { get; set; }

        public int? LastReadingMeter { get; set; }


                       
    }
}
