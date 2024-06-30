using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ERP.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using ERP.Services;

namespace ERP.Controllers
{

        




        [Authorize(Roles = "admin")]

    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EmployeeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public IActionResult Index()
        {

            var employees = context.Employees.ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            if (User.IsInRole("admin"))
            {
                return View();

            }
            return Forbid();

        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto employeeDto)
        {
            if (User.IsInRole("admin"))
            {

                if (!ModelState.IsValid)
                {
                    return View(employeeDto);
                }

                Employee employee = new Employee()
                {
                    Employee_name = employeeDto.Employee_name,
                    Employee_surname = employeeDto.Employee_surname,
                    Employee_address = employeeDto.Employee_address,
                    Employee_phone = employeeDto.Employee_phone,
                    Salary = employeeDto.Salary,
                    CreatedAt = DateTime.Now,
                };

                context.Employees.Add(employee);
                context.SaveChanges();

                var email = $"{employeeDto.Employee_name}.{employeeDto.Employee_surname}@gmail.com".ToLower();
                var normalizedEmail = email.ToUpper();

                var user = new ApplicationUser 
                {
                    UserName = email,
                    NormalizedUserName = normalizedEmail,
                    Email = email,
                    NormalizedEmail = normalizedEmail,
                    FirstName = employeeDto.Employee_name,
                    LastName = employeeDto.Employee_surname,
                    Address = employeeDto.Employee_address,
                    PhoneNumber = employeeDto.Employee_phone,
                    CreatedAt = DateTime.Now
                };
                var result = await _userManager.CreateAsync(user, "Sifra123.");
                if (result.Succeeded)
                {
                    var roleExist = await _roleManager.RoleExistsAsync("zaposleni");
                    if (!roleExist)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("zaposleni"));
                    }
                    await _userManager.AddToRoleAsync(user, "zaposleni");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(employeeDto);
                }

                return RedirectToAction("Index", "Employee");
            }
            return Forbid();
        }

        public IActionResult Edit(int Employee_ID)
        {
            if (User.IsInRole("admin"))
            {
                var employee = context.Employees.Find(Employee_ID);

                if (employee == null)
                {
                    return RedirectToAction("Index", "Employee");
                }

                var employeeDto = new EmployeeDto()
                {
                    Employee_name = employee.Employee_name,
                    Employee_surname = employee.Employee_surname,
                    Employee_address = employee.Employee_address,
                    Employee_phone = employee.Employee_phone,
                    Salary = employee.Salary,
                };

                ViewData["Employee_ID"] = employee.Employee_ID;
                ViewData["CreatedAt"] = employee.CreatedAt.ToString("MM/dd/yyyy");


                return View(employeeDto);
            }
            else
            {
                return Forbid();
            }
        }

        [HttpPost]
        public IActionResult Edit(int Employee_ID, EmployeeDto employeeDto)
        {
            if (User.IsInRole("admin"))
            {

                var employee = context.Employees.Find(Employee_ID);

                if (employee == null)
                {
                    return RedirectToAction("Index", "Employee");
                }

                if (!ModelState.IsValid)
                {
                    ViewData["Employee_ID"] = employee.Employee_ID;
                    ViewData["CreatedAt"] = employee.CreatedAt.ToString("MM/dd/yyyy");

                    return View(employeeDto);
                }

                employee.Employee_name = employeeDto.Employee_name;
                employee.Employee_surname = employeeDto.Employee_surname;
                employee.Employee_address = employeeDto.Employee_address;
                employee.Employee_phone = employeeDto.Employee_phone;
                employee.Salary = employeeDto.Salary;

                context.SaveChanges();

                return RedirectToAction("Index", "Employee");

            }
            else
            {
                return Forbid();
            }
        }

        public IActionResult Delete(int Employee_ID)
        {
            if (User.IsInRole("admin"))
            {
                var employee = context.Employees.Find(Employee_ID);
                if (employee == null)
                {
                    return RedirectToAction("Index", "Employee");
                }

                context.Employees.Remove(employee);
                context.SaveChanges(true);


                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return Forbid();
            }
        }

    }
}
