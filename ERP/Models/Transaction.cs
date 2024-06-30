using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Transaction
    {
        [Key]
        public int Transaction_ID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}