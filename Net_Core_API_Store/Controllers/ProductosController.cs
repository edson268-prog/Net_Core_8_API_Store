using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net_Core_API_Store.Contexto;
using Net_Core_API_Store.Implementations;
using Net_Core_API_Store.Interfaces;
using Net_Core_API_Store.Models;

namespace Net_Core_API_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IProductoRepository _productoRepository;

        //public ProductosController(ApplicationDbContext context)
        public ProductosController(IProductoRepository productRepository)
        {
            //_context = context;
            _productoRepository = productRepository;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProducto()
        {
            //return await _context.Producto.ToListAsync();

            var productos = await _productoRepository.GetAllAsync();
            return Ok(productos);
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            //var producto = await _context.Producto.FindAsync(id);

            var producto = await _productoRepository.GetByIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            //_context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _productoRepository.UpdateAsync(producto);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            //_context.Producto.Add(producto);
            //await _context.SaveChangesAsync();

            await _productoRepository.AddAsync(producto);

            return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            //var producto = await _context.Producto.FindAsync(id);
            var producto = await _productoRepository.GetByIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            //_context.Producto.Remove(producto);
            //await _context.SaveChangesAsync();

            await _productoRepository.DeleteAsync(producto);

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            //return _context.Producto.Any(e => e.Id == id);
            return _productoRepository.ExistsAsync(id).Result;
        }
    }
}
