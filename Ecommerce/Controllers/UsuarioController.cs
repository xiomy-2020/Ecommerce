using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private IUsuarioServices _db;
        public UsuarioController(IUsuarioServices db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            return Ok(await _db.ObtenerUsuarios());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(string id)
        {
            return Ok(await _db.ObtenerUsuarioPorId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] UsuarioDto usuario)
        {
            await _db.InsertarUsuario(usuario);
            return Ok(new { status = 201, message = "Usuario Creado Correctamente" });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario([FromBody] Usuario usuario, string id)
        {
            await _db.ActualizarUsuario(usuario);
            return Ok(new { status = 200, message = "Usuario Actualizado Correctamente" });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario(string id)
        {
            await _db.EliminarUsuario(id);
            return Ok(new {status=204,message="Usuario eliminado Correctamente"});
        }
    }
}
