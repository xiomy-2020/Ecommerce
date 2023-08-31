using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface IVentaServices
    {
        Task InsertarVenta(VentaDto venta);

        Task ActualizarVenta(Venta venta);

        Task EliminarVenta(string id);

        Task<List<Venta>> ObtenerVentas();        

        Task<Venta> ObtenerVentaPorId(string id);
    }
}
