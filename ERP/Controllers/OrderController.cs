using Microsoft.AspNetCore.Mvc;
using ERP.Models;
using System.Linq;
using ERP.Services;

namespace ERP.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult OrderHistory()
        {
            string userId = User.Identity.Name;

            var cartItems = _context.CartItems
                                    .Where(ci => ci.UserId == userId)
                                    .ToList();

            return View(cartItems);
        }
    }
}
