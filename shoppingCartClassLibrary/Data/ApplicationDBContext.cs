using Microsoft.EntityFrameworkCore;
using shoppingCartClassLibrary.Models;
using System.Collections.Generic;


namespace shoppingCartClassLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}

