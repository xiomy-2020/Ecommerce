using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface ICategoriaServices
    {
        Task InsertarCategoria(CategoriaDto categoria);

        Task ActualizarCategoria(Categoria categoria);

        Task EliminarCategoria(string id);

        Task<List<Categoria>> ObtenerCategorias();

        Task<Categoria> ObtenerCategoriaPorId(string id);
    }
}
