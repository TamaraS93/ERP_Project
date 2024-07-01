
namespace ERP.Models
{
    public class CartViewModel
    {
        public List<CartItemDto> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
