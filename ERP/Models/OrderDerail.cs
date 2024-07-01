using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public int Odred_Detail_ID { get; set; }
        [Required]
        public int Order_ID { get; set; }
        [Required]
        public int Product_ID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}