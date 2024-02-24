using Microsoft.EntityFrameworkCore;
using shoppingCartClassLibrary.Models;

namespace shoppingCartClassLibrary.Data
{   
    public class SecurityDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
