#nullable disable
using System;
using System.Collections.Generic;

namespace WaterBill.DAL.Data.Entities
{
    public  class Subscriber
    {
        public Subscriber()
        {

        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Mobile { get; set; }
        public string Reasons { get; set; }
        
        public virtual ICollection<Subscription> SubscriptionFiles { get; set; } = new HashSet<Subscription>();
       
        
    }
}