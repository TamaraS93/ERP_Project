using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CartDetail")]
    public class CartDetail
    {
        [Key]
        public int CartDetail_ID { get; set; }

        [Required]
        public int Shopping_Cart_ID { get; set; }
        [Required]
        public int Product_ID { get; set; }
        [Required]
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

    }
}