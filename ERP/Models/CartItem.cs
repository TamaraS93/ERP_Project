using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
    }
}
