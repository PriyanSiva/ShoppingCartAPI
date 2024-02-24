using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoppingCartClassLibrary.Data;

namespace shoppingCartAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ShoppingCartController : Controller
{
    private readonly ApplicationDbContext _context;

    public ShoppingCartController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Add a Get endpoint that returns all products in the user's shopping cart.
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = User.Identity.Name;
        var cart = await _context.ShoppingCarts.Include(c => c.Products).FirstOrDefaultAsync(c => c.User == user);
        return Ok(cart?.Products);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var user = User.Identity.Name;
        var cart = await _context.ShoppingCarts.Include(c => c.Products).FirstOrDefaultAsync(c => c.User == user);
        var product = cart?.Products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            cart.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        return Ok();
    }

    // Add a Post endpoint that takes a single ID and adds the item to the shopping cart. Make sure to create the Shopping Cart if needed and Assign the Current Users Email to the User property.
    [HttpPost("{id}")]
    public async Task<IActionResult> Add(int id)
    {
        var user = User.Identity.Name;
        var cart = await _context.ShoppingCarts.Include(c => c.Products).FirstOrDefaultAsync(c => c.User == user);
        var product = await _context.Products.FindAsync(id);
        if (cart == null)
        {
            cart = new ShoppingCart { User = user, Products = new List<Product> { product } };
            _context.ShoppingCarts.Add(cart);
        }
        else
        {
            cart.Products.Add(product);
        }
        await _context.SaveChangesAsync();
        return Ok();
    }
}