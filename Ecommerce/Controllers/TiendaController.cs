using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendaController : Controller
    {
        private ITiendaServices _db;

        public TiendaController(ITiendaServices db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetTiendas()
        {
            return Ok(await _db.ObtenerTiendas());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTienda(string id)
        {
            return Ok(await _db.ObtenerTiendaPorId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateTienda([FromBody] TiendaDto tienda)
        {
            await _db.InsertarTienda(tienda);
            return Ok(new { status = 201, message = "Tienda Creada Correctamente" });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTienda([FromBody] Tienda tienda, string id)
        {
            await _db.ActualizarTienda(tienda);
            return Ok(new { status = 200, message = "Tienda Actualizada Correctamente" });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTienda(string id)
        {
            await _db.EliminarTienda(id);
            return Ok(new {status=204,message = "Tienda Eliminada Correctamente" });
        }
    }
}
