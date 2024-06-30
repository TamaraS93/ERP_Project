using System.Collections.Generic;
using ERP.Models;

namespace ERP.Services
{
    public interface ICartService
    {
        void AddToCart(string userId, Product product);
        void RemoveFromCart(string userId, int productId);
        List<CartItemDto> GetCartItems(string userId);
        void ClearCart(string userId);
        decimal CalculateCartTotal(string userId);
        void UpdateCartItem(int cartItemId, int quantity);
        Task<List<CartItem>> GetCartItemsAsync(string userId);
    }
}