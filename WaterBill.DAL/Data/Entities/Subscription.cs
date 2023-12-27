#nullable disable
using System;
using System.Collections.Generic;

namespace WaterBill.DAL.Data.Entities
{
    public  class Subscription
    {
        public string Id { get; set; }
        public int UnitNo { get; set; }
        public bool IsThereSanitation { get; set; }
        public int LastReadingMeter { get; set; }
        public string Reasons { get; set; }

        public string RrealEstateTypesCode { get; set; } // forign key => RrealEstateType
        public virtual RrealEstateType RrealEstateType { get; set; } // Navigation Property => RrealEstateType
       
        public string SubscriberCode { get; set; } // forign key =>Subscriber
        public virtual Subscriber Subscriber { get; set; } // Navigation Property => Subscriber
    }
}