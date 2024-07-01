using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ERP.Models;
using Microsoft.AspNetCore.Authorization;
using ERP.Services;

namespace ERP.Controllers
{
    [Authorize(Roles = "admin,zaposleni")]
    public class CustomersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public CustomersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {

            var customer = _context.Customers.ToList();
            return View(customer);
        }

        public IActionResult Create()
        {
            if (User.IsInRole("admin") || User.IsInRole("zaposleni"))
            {
                return View();

            }
            return Forbid();

        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto customerDto)
        {
            if (User.IsInRole("admin"))
            {

                if (!ModelState.IsValid)
                {
                    return View(customerDto);
                }

                Customer customer = new Customer()
                {
                    Customer_Name = customerDto.Customer_name,
                    Customer_LastName = customerDto.Customer_LastName,
                    Customer_address = customerDto.Customer_address,
                    Customer_phone = customerDto.Customer_phone,
                    CreatedAt = DateTime.Now,
                };

                _context.Customers.Add(customer);
                _context.SaveChanges();

                var email = $"{customerDto.Customer_name}.{customerDto.Customer_LastName}@gmail.com".ToLower();
                var normalizedEmail = email.ToUpper();

                var user = new ApplicationUser
                {
                    UserName = email,
                    NormalizedUserName = normalizedEmail,
                    Email = email,
                    NormalizedEmail = normalizedEmail,
                    FirstName = customerDto.Customer_name,
                    LastName = customerDto.Customer_LastName,
                    Address = customerDto.Customer_address,
                    PhoneNumber = customerDto.Customer_phone,
                    CreatedAt = DateTime.Now
                };
                var result = await _userManager.CreateAsync(user, "Sifra123.");
                if (result.Succeeded)
                {
                    var roleExist = await _roleManager.RoleExistsAsync("kupac");
                    if (!roleExist)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("kupac"));
                    }
                    await _userManager.AddToRoleAsync(user, "kupac");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(customerDto);
                }

                return RedirectToAction("Index", "Customers");
            }
            return Forbid();
        }


        public IActionResult Edit(int Customer_ID)
        {
            if (User.IsInRole("admin") || ((User.IsInRole("zaposleni"))))
            {
                var customer = _context.Customers.Find(Customer_ID);

                if (customer == null)
                {
                    return RedirectToAction("Index", "Curomers");
                }

                var customerDto = new CustomerDto()
                {
                    Customer_name = customer.Customer_Name,
                    Customer_LastName = customer.Customer_LastName,
                    Customer_address = customer.Customer_address,
                    Customer_phone = customer.Customer_phone,
                };

                ViewData["Customer_ID"] = customer.Customer_ID;
                ViewData["CreatedAt"] = customer.CreatedAt.ToString("MM/dd/yyyy");


                return View(customerDto);
            }
            else
            {
                return Forbid();
            }
        }



        [HttpPost]
        public IActionResult Edit(int Customer_ID, CustomerDto customerDto)
        {
            if (User.IsInRole("admin") || (User.IsInRole("zaposleni")))
            {

                var customer = _context.Customers.Find(Customer_ID);

                if (customer == null)
                {
                    return RedirectToAction("Index", "Customers");
                }

                if (!ModelState.IsValid)
                {
                    ViewData["Customer_ID"] = customer.Customer_ID;
                    ViewData["CreatedAt"] = customer.CreatedAt.ToString("MM/dd/yyyy");

                    return View(customerDto);
                }

                customer.Customer_Name = customerDto.Customer_name;
                customer.Customer_LastName = customerDto.Customer_LastName;
                customer.Customer_address = customerDto.Customer_address;
                customer.Customer_phone = customerDto.Customer_phone;

                _context.SaveChanges();

                return RedirectToAction("Index", "Customers");

            }
            else
            {
                return Forbid();
            }
        }

        public IActionResult Delete(int Customer_ID)
        {
            if (User.IsInRole("admin"))
            {
                var customer = _context.Customers.Find(Customer_ID);
                if (customer == null)
                {
                    return RedirectToAction("Index", "Customers");
                }

                _context.Customers.Remove(customer);
                _context.SaveChanges(true);


                return RedirectToAction("Index", "Customers");
            }
            else
            {
                return Forbid();
            }
        }
    }
}