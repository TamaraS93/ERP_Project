using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ERP.Models;
using ERP.Services;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Transactions()
    {
        var transactions = _context.Transactions.ToList();
        return View(transactions);
    }
}