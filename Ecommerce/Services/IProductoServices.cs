using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface IProductoServices
    {
        Task InsertarProducto(ProductoDto producto);

        Task ActualizarProducto(Producto producto);

        Task EliminarProducto(string id);

        Task<List<Producto>> ObtenerProductos();

        Task<Producto> ObtenerProductoPorId(string id);
    }
}
