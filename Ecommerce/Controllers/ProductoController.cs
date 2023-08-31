using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private IProductoServices db = new ProductoServices();

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            return Ok(await db.ObtenerProductos());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(string id)
        {
            return Ok(await db.ObtenerProductoPorId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody]ProductoDto producto)
        {
            await db.InsertarProducto(producto);
            return Ok(new { status = 201, message = "Producto creado correctamente" });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto([FromBody]Producto producto,string id)
        {
            await db.ActualizarProducto(producto);
            return Ok(new { status = 200, message = "Producto creado correctamente" });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProducto(string id)
        {
            await db.EliminarProducto(id);
            return Ok(new {status=204, message = "Producto eliminado correctamente"});
        }
    }
}
