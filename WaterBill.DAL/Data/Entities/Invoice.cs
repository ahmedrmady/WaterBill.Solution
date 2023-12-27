#nullable disable
using System;
using System.Collections.Generic;

namespace WaterBill.DAL.Data.Entities
{
    public class Invoice
    {
        public string Id { get; set; }
        public string Year { get; set; }
        
        public string RrealEstateTypeCode { get; set; } //forign key => RrealEstateType
        public virtual RrealEstateType RrealEstateType { get; set; } // navigation Property => RrealEstateType
       
        public string SubscriptionId { get; set; } //forign key => Subscription
        public virtual Subscription Subscription { get; set; } // navigation Property (one) =>Subscription

        public string SubscriberId { get; set; }  //  forign key =>  Subscriber    
        public virtual Subscriber Subscriber { get; set; } // navigation Property (one) => Subscriber
        
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

        public string Reasons { get; set; }
    }
}