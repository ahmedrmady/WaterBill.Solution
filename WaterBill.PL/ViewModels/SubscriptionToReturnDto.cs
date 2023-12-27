using System.ComponentModel.DataAnnotations;

namespace WaterBill.PL.ViewModels
{
    public class SubscriptionToReturnDto
    {

        public string Id { get; set; }

        
        public string SubscriberCode { get; set; }


        public string RrealEstateTypesCode { get; set; }

     

        public string SubscriberName { get; set; }

        
        public string Mobile { get; set; }

        public int UnitNo { get; set; }

        public string RrealEstateName { get; set; }

        public int LastReadingMeter { get; set; }

        public bool IsThereSanitation { get; set; }

        public string Reasons { get; set; } 


    }
}
