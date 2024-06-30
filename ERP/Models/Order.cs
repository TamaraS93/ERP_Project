using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Order_ID {get; set;}
        [Required]
        public int User_ID {get; set;}
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [Required]
        public int Order_status_ID { get; set; }
        public bool IsDeleted { get; set; } = false;

        public OrderStatus OrderStatus { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }
    }
}
