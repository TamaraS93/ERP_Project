using ERP.Models;
using ERP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ERP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;
        private readonly ICartService cartService;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment environment, ICartService cartService)
        {
            this.context = context;
            this.environment = environment;
            this.cartService = cartService;
        }
        public IActionResult Index(string searchString, string category, string CategoryID)
        {
            var products = context.Products.AsQueryable();

            Console.WriteLine(CategoryID);
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Product_name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(CategoryID) && CategoryID != "Izaberi..")
            {
                products = products.Where(p => p.Category.Equals(CategoryID));
            }

            ViewData["SearchString"] = searchString;

            return View(products.ToList());
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
        public IActionResult Create(ProductDto productDto)
        {
            if (User.IsInRole("admin") || User.IsInRole("zaposleni"))
            {

                if (productDto.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "Slika je obavezna");
                }

                if (!ModelState.IsValid)
                {
                    return View(productDto);
                }

                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(productDto.ImageFile!.FileName);

                string imageFullPath = environment.WebRootPath + "/Images/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    productDto.ImageFile.CopyTo(stream);
                }

                Product product = new Product()
                {
                    Product_name = productDto.Product_name,
                    Brand = productDto.Brand,
                    Category = productDto.Category,
                    Price = productDto.Price,
                    Description = productDto.Description,
                    ImageFileName = newFileName,
                    CreatedAt = DateTime.Now,
                };

                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index", "Products");
            }
            return Forbid();
        }


        public IActionResult Edit(int Product_ID)
        {
            if (User.IsInRole("admin") || User.IsInRole("zaposleni"))
            {
                var product = context.Products.Find(Product_ID);

                if (product == null)
                {
                    return RedirectToAction("Index", "Products");
                }

                var productDto = new ProductDto()
                {
                    Product_name = product.Product_name,
                    Brand = product.Brand,
                    Category = product.Category,
                    Price = product.Price,
                    Description = product.Description,
                };

                ViewData["ProductID"] = product.Product_ID;
                ViewData["ImageFileName"] = product.ImageFileName;
                ViewData["CreatedAt"] = product.CreatedAt.ToString("MM/dd/yyyy");


                return View(productDto);
            }
            else
            {
                return Forbid();
            }
        }

        [HttpPost]
        public IActionResult Edit(int Product_ID, ProductDto productDto)
        {
            if (User.IsInRole("admin") || User.IsInRole("zaposleni"))
            {

                var product = context.Products.Find(Product_ID);

                if (product == null)
                {
                    return RedirectToAction("Index", "Products");
                }

                if (!ModelState.IsValid)
                {
                    ViewData["ProductID"] = product.Product_ID;
                    ViewData["ImageFileName"] = product.ImageFileName;
                    ViewData["CreatedAt"] = product.CreatedAt.ToString("MM/dd/yyyy");

                    return View(productDto);
                }

                string newFileName = product.ImageFileName;
                if (productDto.ImageFile != null)
                {
                    newFileName = DateTime.Now.ToString("yyyyMMddHHmmssFFF");
                    newFileName += Path.GetExtension(productDto.ImageFile.FileName);

                    string imageFullPath = environment.WebRootPath + "/Images/" + newFileName;
                    using (var stream = System.IO.File.Create(imageFullPath))
                    {
                        productDto.ImageFile.CopyTo(stream);
                    }

                    string oldImageFullPath = environment.WebRootPath + "/Images/" + product.ImageFileName;
                    System.IO.File.Delete(oldImageFullPath);
                }

                product.Product_name = productDto.Product_name;
                product.Brand = productDto.Brand;
                product.Category = productDto.Category;
                product.Price = productDto.Price;
                product.Description = productDto.Description;
                product.ImageFileName = newFileName;

                context.SaveChanges();

                return RedirectToAction("Index", "Products");

            }
            else
            {
                return Forbid();
            }
        }

        public IActionResult Delete(int Product_ID)
        {
            if (User.IsInRole("admin") || User.IsInRole("zaposleni"))
            {
                var product = context.Products.Find(Product_ID);
                if (product == null)
                {
                    return RedirectToAction("Index", "Products");
                }

                string imageFullPath = environment.WebRootPath + "/Images/" + product.ImageFileName;
                System.IO.File.Delete(imageFullPath);

                context.Products.Remove(product);
                context.SaveChanges(true);


                return RedirectToAction("Index", "Products");
            }
            else
            {
                return Forbid();
            }
        }

        [Authorize(Roles = "kupac")]
        public IActionResult AddToCart(int Product_ID)
        {
            var product = context.Products.Find(Product_ID);

            if (product == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            cartService.AddToCart(userId, product);
            return RedirectToAction("Index", "Products");
        }
    }
}