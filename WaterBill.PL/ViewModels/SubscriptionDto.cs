using System.ComponentModel.DataAnnotations;

namespace WaterBill.PL.ViewModels
{
    public class SubscriptionDto
    {
       
        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string SubscriberCode { get; set; } 


        [Required]
        [Range(0, 99)]
        public int UnitNo { get; set; }

        [Required]
        public string RrealEstateTypesCode { get; set; }

        [Required]
        public bool IsThereSanitation { get; set; }

        

    }

}
