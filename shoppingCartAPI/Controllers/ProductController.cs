using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoppingCartClassLibrary.Data;
using shoppingCartClassLibrary.Models;

namespace shoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add a Get endpoint that returns all products.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        // Add a Get endpoint that takes a category Id and returns all products in that category.
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var products = await _context.Products.Where(p => p.Category.Id == categoryId).ToListAsync();
            return Ok(products);
        }

        // Add a Post endpoint that takes a single product and adds it to the database.
        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
