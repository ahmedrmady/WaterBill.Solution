#nullable disable
using System;
using System.Collections.Generic;

namespace WaterBill.DAL.Data.Entities
{
    public  class RrealEstateType
    {
        public RrealEstateType()
        {
            
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Reasons { get; set; }

        public virtual ICollection<Subscription> SubscriptionFiles { get; set; } = new HashSet<Subscription>();
    }
}