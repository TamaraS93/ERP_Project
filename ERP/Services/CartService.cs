using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<CartItem>> GetCartItemsAsync(string userId)
        {
            var cartItems = await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .ToListAsync();

            return cartItems;
        }

        public void AddToCart(string userId, Product product)
        {
            var cart = _context.ShoppingCarts
                .Include(c => c.CartItems)
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new ShoppingCart { UserId = userId, CartItems = new List<CartItem>() };
                _context.ShoppingCarts.Add(cart);
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == product.Product_ID);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ProductId = product.Product_ID,
                    Quantity = 1,
                    Product = product,
                    ProductName = product.Product_name,
                    Price = product.Price,
                    UserId = userId 
                };
                cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            _context.SaveChanges();
        }

        public void RemoveFromCart(string userId, int productId)
        {
            var cart = _context.ShoppingCarts
                .Include(c => c.CartItems)
                .FirstOrDefault(c => c.UserId == userId);

            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

                if (cartItem != null)
                {
                    _context.CartItems.Remove(cartItem);
                    _context.SaveChanges();
                }
            }
        }

        public List<CartItemDto> GetCartItems(string userId)
        {
            var cartItems = _context.CartItems
                .Include(ci => ci.Product)
                .Where(ci => ci.UserId == userId)
                .Select(ci => new CartItemDto
                {
                    CartItemId = ci.CartItemId,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Product_name,
                    Quantity = ci.Quantity,
                    Price = ci.Product.Price
                })
                .ToList();

            return cartItems;
        }

        public void ClearCart(string userId)
        {
            var cart = _context.ShoppingCarts
                .Include(c => c.CartItems)
                .FirstOrDefault(c => c.UserId == userId);

            if (cart != null)
            {
                _context.CartItems.RemoveRange(cart.CartItems);
                _context.SaveChanges();
            }
        }

        public decimal CalculateCartTotal(string userId)
        {
            var total = _context.CartItems
                .Where(ci => ci.UserId == userId)
                .Sum(ci => ci.Quantity * ci.Product.Price);

            return total;
        }

        public void UpdateCartItem(int cartItemId, int quantity)
        {
            var cartItem = _context.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                _context.SaveChanges();
            }
        }
    }
}