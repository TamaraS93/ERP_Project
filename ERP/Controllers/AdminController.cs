using Microsoft.AspNetCore.Mvc;
using ERP.Models;
using ERP.Services;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult FinancialReport()
    {
        var transactions = _context.Transactions.ToList();

        decimal totalSum = transactions.Sum(t => t.Price);

        var viewModel = new FinancialReportViewModel
        {
            Transactions = transactions,
            TotalSum = totalSum
        };

        return View(viewModel);
    }
}