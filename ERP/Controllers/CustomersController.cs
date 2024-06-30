using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ERP.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using ERP.Services;
using System;

namespace ERP.Controllers
{
    [Authorize(Roles = "admin,zaposleni")]
    public class CustomersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public CustomersController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var role = await _roleManager.FindByNameAsync("kupac");
            if (role == null)
            {
                return NotFound();
            }

            var usersInRole = await _context.UserRoles
                .Where(ur => ur.RoleId == role.Id)
                .Select(ur => ur.UserId)
                .ToListAsync();

            var customers = await _context.Users
                .Where(u => usersInRole.Contains(u.Id))
                .ToListAsync();

            return View(customers);
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _context.Users.FirstOrDefault(u => u.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationUser customer)
        {
            if (ModelState.IsValid)
            {
                var existingCustomer = _context.Users.FirstOrDefault(u => u.Id == customer.Id);
                if (existingCustomer == null)
                {
                    return NotFound();
                }

                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.Address = customer.Address;

                try
                {
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Došlo je do greške pri čuvanju. Podaci su možda izmenjeni od trenutka poslednjeg učitavanja.");
                    return View(customer);
                }

            }
            return View(customer);
        }

        public IActionResult Delete(string id)
        {
            if (User.IsInRole("admin") || User.IsInRole("zaposleni"))
            {
                var customer = _context.Users.FirstOrDefault(u => u.Id == id);
                if (customer == null)
                {
                    return RedirectToAction("Index", "Customers");
                }

                _context.Users.Remove(customer);
                _context.SaveChanges(true);
                return RedirectToAction("Index", "Customers");
            }
            else
            {
                return Forbid();
            }

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var customer = _context.Users.FirstOrDefault(u => u.Id == id);
            if (customer != null)
            {
                _context.Users.Remove(customer);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}