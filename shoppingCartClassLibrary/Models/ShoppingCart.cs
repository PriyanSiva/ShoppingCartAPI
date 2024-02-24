using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoppingCartClassLibrary.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public User User { get; set; } // Replace 'User' with your actual user model
        public List<Product> Products { get; set; } // List of products in the cart
    }
}
