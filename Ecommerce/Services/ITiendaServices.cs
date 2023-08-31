using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface ITiendaServices
    {
        Task InsertarTienda(TiendaDto tienda);

        Task ActualizarTienda(Tienda tienda);

        Task EliminarTienda(string id);

        Task<List<Tienda>> ObtenerTiendas();

        Task<Tienda> ObtenerTiendaPorId(string id);
    }
}
