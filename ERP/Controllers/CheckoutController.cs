using ERP.Models;
using ERP.Services;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System.Security.Claims;

[Route("create-checkout-session")]
[ApiController]

public class CheckoutController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ICartService _cartService;

    public CheckoutController(ApplicationDbContext context, ICartService cartService)
    {
        _context = context;
        _cartService = cartService;
    }

    [HttpPost]
    public async Task<ActionResult> Create(decimal cartTotal)
    {
        var domain = "http://localhost:7133";


        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string>
            {
                "card",
                "paypal"
            },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    Price = "price_1PWo8wJQFmrnI2wNIfwJVTnC",
                    Quantity = 1,
                },
            },
            Mode = "payment",
            SuccessUrl = "https://localhost:7133/Products/Index",
            CancelUrl = "https://localhost:7133/Products/Index",
        };
        var service = new SessionService();

        var transaction = new Transaction
        {
            ProductName = "Rich Nourishing mleko za telo , za suvu kožu", 
            Quantity = 1, 
            Price = 5,
            CustomerEmail = "test.test@example.com", 
            TransactionDate = DateTime.Now 
        };

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _cartService.ClearCart(userId);

        Session session = service.Create(options);

        Response.Headers.Add("Location", session.Url);
        return new StatusCodeResult(303);
    }

    [HttpGet("success")]
    public IActionResult Success(int transactionId)
    {
        var transaction = _context.Transactions.Find(transactionId);

        if (transaction == null)
        {
            return NotFound();
        }

        var transactionViewModel = new TransactionViewModel(
            transaction.Transaction_ID,
            transaction.TransactionDate,
            transaction.Price
        );

        return View(transactionViewModel);
    }
}