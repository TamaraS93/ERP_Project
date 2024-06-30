using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class ProductDto
    {
        [Required, MaxLength(100)]
        public string Product_name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Category { get; set; } = "";
        [Required, MaxLength(100)]
        public string Brand { get; set; } = "";
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; } = "";
        public IFormFile? ImageFile { get; set; }

    }
}