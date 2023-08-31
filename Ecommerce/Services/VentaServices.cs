using Ecommerce.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ecommerce.Services
{
    public class VentaServices : IVentaServices
    {
        internal MongoDBServices _services = new MongoDBServices();
        private IMongoCollection<Venta> _ventaCollection;

        public VentaServices()
        {
            _ventaCollection = _services.db.GetCollection<Venta>("Ventas");
            
        }
        public async Task ActualizarVenta(Venta venta)
        {
            var vnt = Builders<Venta>.Filter.Eq(s=>s.Id,venta.Id);
            await _ventaCollection.ReplaceOneAsync(vnt,venta);
        }

        public async Task EliminarVenta(string id)
        {
            var vnt = Builders<Venta>.Filter.Eq("_id", new ObjectId(id));
            await _ventaCollection.DeleteOneAsync(vnt);
        }

        public async Task InsertarVenta(VentaDto ventaDto)
        {
            Venta venta = new Venta();
            venta.FechaVenta = ventaDto.FechaVenta;
            venta.ProductoId = ventaDto.ProductoId;
            venta.UsuarioId = ventaDto.UsuarioId;
            venta.TiendaId = ventaDto.TiendaId;
            await _ventaCollection.InsertOneAsync(venta);
        }

        public async Task<Venta> ObtenerVentaPorId(string id)
        {
            return await _ventaCollection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstOrDefaultAsync();
        }

        public async Task<List<Venta>> ObtenerVentas()
        {
            return await _ventaCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
        
    }
}
