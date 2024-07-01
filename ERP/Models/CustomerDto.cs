using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class CustomerDto
    {
        [Required, MaxLength(100)]
        public string Customer_name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Customer_LastName { get; set; } = "";
        [Required, MaxLength(100)]
        public string Customer_address { get; set; } = "";
        [Required]
        public string Customer_phone { get; set; } = "";

    }
}
