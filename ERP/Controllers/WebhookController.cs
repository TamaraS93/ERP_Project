using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using ERP.Models;
using ERP.Services;

[Route("webhook")]
[ApiController]
public class WebhookController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<WebhookController> _logger;
    private readonly string _webhookSecret;

    public WebhookController(ApplicationDbContext context, ILogger<WebhookController> logger)
    {
        _context = context;
        _logger = logger;
        _webhookSecret = "whsec_BpL2flwHUbGLVtdfX4WgUqbihu8SuuQt";
    }

    [HttpPost]
    public async Task<IActionResult> Index()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        try
        {

            var stripeEvent = EventUtility.ConstructEvent(
                json,
                Request.Headers["Stripe-Signature"],
                _webhookSecret
            );

            if (stripeEvent.Type == Events.CheckoutSessionCompleted)
            {
                var session = stripeEvent.Data.Object as Session;
                var customerEmail = session.CustomerDetails.Email;
                // var lineItems = session.DisplayItems;
                // var amountTotal = session.AmountTotal;
                var service = new SessionService();
                var sessionLineItems = service.ListLineItems(session.Id);

                foreach (var item in sessionLineItems.Data)
                {
                    var transaction = new Transaction
                    {
                        ProductName = item.Description,
                        Quantity = (int)item.Quantity,
                        Price = (int)item.AmountTotal,
                        CustomerEmail = customerEmail,
                        TransactionDate = DateTime.Now
                    };
                    _context.Transactions.Add(transaction);
                }
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Transaction completed for {customerEmail}");
            }

            return Ok();
        }
        catch (StripeException e)
        {
            _logger.LogError($"Stripe exception: {e.Message}");
            return BadRequest();
        }
    }
}
