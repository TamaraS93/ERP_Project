using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Product_ID { get; set; }
        [MaxLength(100)]
        public string Product_name { get; set; } = "";
        [MaxLength(100)]
        public string Brand { get; set; } = "";

        [MaxLength(100)]
        public string Category { get; set; } = "";

        [Precision(16, 2)]
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
        [MaxLength(100)]
        public string ImageFileName { get; set; } = "";
        public DateTime CreatedAt { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }
    }
}