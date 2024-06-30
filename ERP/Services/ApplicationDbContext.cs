using ERP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERP.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {  

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var zaposleni = new IdentityRole("zaposleni");
            zaposleni.NormalizedName = "zaposleni";

            var kupac = new IdentityRole("kupac");
            kupac.NormalizedName = "kupac";

            builder.Entity<IdentityRole>().HasData(admin, zaposleni, kupac);

        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Transaction> Transactions { get; set; }


    }
}
