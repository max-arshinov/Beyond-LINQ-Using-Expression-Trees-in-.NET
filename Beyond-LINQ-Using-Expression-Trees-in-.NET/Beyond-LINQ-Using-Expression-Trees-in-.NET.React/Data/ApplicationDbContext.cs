using Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) 
            : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var laptopCategory = new Category() { Name = "Laptops", Rating = 30, Id = 1 };
            var smartphoneCategory = new Category() { Name = "SmartPhones", Rating = 60, Id = 2 };
            builder.Entity<Category>().HasData(laptopCategory, smartphoneCategory);
            builder.Entity<Product>().HasData(
                new Product() { Name = "Apple MacBook Air 13 Mid 2017", CategoryId = 1, Price = 1000, Id = 1 },
                new Product() { Name = "Apple MacBook Pro 16 Late 2019", CategoryId = 1, Price = 2500, Id = 2 },
                new Product() { Name = "Xiaomi RedmiBook 14", CategoryId = 1, Price = 580, Id = 3 },
                new Product() { Name = "Lenovo Ideapad L340-17", CategoryId = 1, Price = 430, Id = 4 },
                new Product() { Name = "iPhone Xr 64GB", CategoryId = 2, Price = 650, Id = 5 },
                new Product() { Name = "iPhone 11 128GB", CategoryId = 2, Price = 870, Id = 6 },
                new Product() { Name = "Redmi Note 8T", CategoryId = 2, Price = 160, Id = 7 },
                new Product() { Name = "Redmi Note 9 Pro", CategoryId = 2, Price = 300, Id = 8 }
            );
        }

        public DbSet<Product> Products { get; set; }
        
        public DbSet<Category> Categories { get; set; }
    }
}