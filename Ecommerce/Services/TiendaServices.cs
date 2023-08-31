using Ecommerce.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ecommerce.Services
{
    public class TiendaServices : ITiendaServices
    {
        internal MongoDBServices _services = new MongoDBServices();

        private IMongoCollection<Tienda> _tienda;

        public TiendaServices() 
        {
            _tienda = _services.db.GetCollection<Tienda>("Tiendas");
        }

        public async Task ActualizarTienda(Tienda tienda)
        {
            var tnd = Builders<Tienda>.Filter.Eq(s => s.Id, tienda.Id);
            await _tienda.ReplaceOneAsync(tnd, tienda);
        }

        public async Task EliminarTienda(string id)
        {
            var tnd = Builders<Tienda>.Filter.Eq("_id", new ObjectId(id));
            await _tienda.DeleteOneAsync(tnd);
        }

        public async Task InsertarTienda(TiendaDto tiendaDto)
        {
            Tienda tienda = new Tienda();
            tienda.Nit = tiendaDto.Nit;
            tienda.Nombre = tiendaDto.Nombre;
            await _tienda.InsertOneAsync(tienda);
        }

        public async Task<Tienda> ObtenerTiendaPorId(string id)
        {
            return await _tienda.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstOrDefaultAsync();
        }

        public async Task<List<Tienda>> ObtenerTiendas()
        {
            return await _tienda.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
    }
}
