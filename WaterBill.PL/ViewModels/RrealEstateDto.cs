using System.ComponentModel.DataAnnotations;

namespace WaterBill.PL.ViewModels
{
    public class RrealEstateDto
    {
        [Required]
        [MaxLength(1)]
        public string Code { get; set; }
        
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
