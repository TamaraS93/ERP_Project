using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Customer_ID { get; set; }
        [MaxLength(100)]
        public string Customer_Name { get; set; } = "";

        [MaxLength(100)]
        public string Customer_LastName { get; set; } = "";

        [MaxLength(100)]
        public string Customer_address { get; set; } = "";
        [MaxLength(100)]
        public string Customer_phone { get; set; } = "";
        public DateTime CreatedAt { get; set; }



    }
}

