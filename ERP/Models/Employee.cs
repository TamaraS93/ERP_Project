using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; } 

        [MaxLength(100)]
        public string Employee_name { get; set; } = "";

        [MaxLength(100)]
        public string Employee_surname { get; set; } = "";

        [MaxLength(100)]
        public string Employee_address { get; set; } = "";

        [MaxLength(100)]
        public string Employee_phone { get; set; } = "";

        [Column(TypeName = "decimal(16, 2)")]
        public decimal Salary { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
