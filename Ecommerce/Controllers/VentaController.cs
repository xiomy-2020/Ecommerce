using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private IVentaServices _db;
        public VentaController(IVentaServices db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            return Ok(await _db.ObtenerVentas());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenta(string id)
        {
            return Ok(await _db.ObtenerVentaPorId(id));
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateVenta([FromBody] VentaDto venta)
        {
            await _db.InsertarVenta(venta);
            return Ok(new { status = 204, message = "Venta Creada Correctamente" });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenta([FromBody] Venta venta, string id)
        {
            await _db.ActualizarVenta(venta);
            return Ok(new { status = 200, message = "Venta Actualizada Correctamente" });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteVenta(string id)
        {
            await _db.EliminarVenta(id);
            return Ok(new {status=204,message="Venta Eliminada Correctamente"});
        }

    }
}
