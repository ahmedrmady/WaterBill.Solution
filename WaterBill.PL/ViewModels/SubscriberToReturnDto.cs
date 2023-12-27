using System.ComponentModel.DataAnnotations;

namespace WaterBill.PL.ViewModels
{
    public class SubscriberToReturnDto:SubscriberDto
    {

        public int Serial { get; set; }

        public int NumberOfSubscriptions { get; set; }

        public string Reasons { get; set; }

    }
}
