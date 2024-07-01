using ERP.Models;
using ERP.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class CartController : Controller
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    public IActionResult Index()
    {
        string userId = GetCurrentUserId();
        var cartItems = _cartService.GetCartItems(userId);
        decimal cartTotal = _cartService.CalculateCartTotal(userId);

        var model = new CartViewModel
        {
            CartItems = cartItems,
            CartTotal = cartTotal
        };

        return View(model);
    }

    private string GetCurrentUserId()
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        return userId;
    }

    [HttpPost]
    public IActionResult UpdateCartItem(int productId, string action)
    {
        var userId = GetCurrentUserId();
        var cartItems = _cartService.GetCartItems(userId);
        var cartItem = cartItems.FirstOrDefault(ci => ci.ProductId == productId);

        if (cartItem != null)
        {
            if (action == "increase")
            {
                cartItem.Quantity++;
            }
            else if (action == "decrease" && cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
            }
            _cartService.UpdateCartItem(cartItem.CartItemId, cartItem.Quantity);
            var updatedCartItems = _cartService.GetCartItems(userId);
            var cartTotal = _cartService.CalculateCartTotal(userId);

            return Json(new { success = true, cartItems = updatedCartItems, cartTotal = cartTotal });
        }
        return Json(new { success = false });
    }

    [HttpPost]
    public IActionResult ClearCart()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        _cartService.ClearCart(userId);

        return Ok();
    }

    [HttpPost]
    public IActionResult RemoveFromCart(int productId)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _cartService.RemoveFromCart(userId, productId);
            var cartItems = _cartService.GetCartItems(userId);
            var cartTotal = _cartService.CalculateCartTotal(userId);

            var cartItemsDto = cartItems.Select(ci => new
            {
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                Price = ci.Price
            });

            return Json(new { success = true, cartItems = cartItemsDto, cartTotal = cartTotal });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Greška prilikom uklanjanja proizvoda iz korpe: " + ex.Message });
        }
    }
}