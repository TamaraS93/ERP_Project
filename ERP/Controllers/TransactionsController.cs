using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ERP.Models;
using System.Linq;
using ERP.Services;

[Authorize(Roles = "admin")]
public class TransactionsController : Controller
{
    private readonly ApplicationDbContext _context;

    public TransactionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var transactions = _context.Transactions.ToList();
        return View(transactions);
    }
}