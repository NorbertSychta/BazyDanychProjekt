using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Areas.Identity.Data;
using Projekt.Models;

namespace Projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
            => await _context.Products.ToListAsync();

        // GET: api/ProductsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return product;
        }

        // POST: api/ProductsApi
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/ProductsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id) return BadRequest();

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Products.AnyAsync(p => p.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/ProductsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
