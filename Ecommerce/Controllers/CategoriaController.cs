using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private ICategoriaServices _db;
        public CategoriaController(ICategoriaServices db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            return Ok(await _db.ObtenerCategorias());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria(string id)
        {
            return Ok(await _db.ObtenerCategoriaPorId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] CategoriaDto categoria)
        {
           await _db.InsertarCategoria(categoria);
            
            return Ok(new { status  = 201 , message = "Categoria creada correctamente" });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria([FromBody] Categoria categoria, string id)
        {
            
            await _db.ActualizarCategoria(categoria);
            return Ok(new { status = 200, message = "Categoria Actualizada correctamente" });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategoria(string id)
        {
            await _db.EliminarCategoria(id);
            return Ok(new { status=204,message= "Categoria Eliminada Correctamente" });
        }
    }

}

