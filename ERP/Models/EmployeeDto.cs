using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class EmployeeDto
    {
        [Required, MaxLength(100)]
        public string Employee_name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Employee_surname { get; set; } = "";
        [Required, MaxLength(100)]
        public string Employee_address { get; set; } = "";
        [Required]
        public string Employee_phone { get; set; } = "";

        [Required]
        public decimal Salary { get; set; }

    }
}
