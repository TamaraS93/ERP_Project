using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("ShoppingCart")]
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }

        [Required]
        public string UserId { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}