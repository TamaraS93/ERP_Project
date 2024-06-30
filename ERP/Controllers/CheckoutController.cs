using ERP.Models;
using ERP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//using Microsoft.Extensions.Options;
//using ERP.Models;
using Stripe.Checkout;
//using Stripe;

[Route("create-checkout-session")]
[ApiController]

public class CheckoutController : Controller
{
    private readonly ApplicationDbContext _context;

    public CheckoutController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public ActionResult Create(decimal cartTotal)
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