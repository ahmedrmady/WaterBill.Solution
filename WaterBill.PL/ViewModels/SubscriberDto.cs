using System.ComponentModel.DataAnnotations;

namespace WaterBill.PL.ViewModels
{
    public class SubscriberDto
    {
        [Required]
        [MaxLength(10)]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]

        public string Name { get; set; }

        [Required]
        [MaxLength(50)]

        public string City { get; set; }
        
        [Required]
        [MaxLength(50)]

        public string Area { get; set; }

        [Required]
        [MaxLength(20)]
        public string Mobile { get; set; }
        
    }
}
