using Ecommerce.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ecommerce.Services
{
    public class ProductoServices : IProductoServices
    {
        internal MongoDBServices _services= new MongoDBServices();

        private IMongoCollection<Producto> _productos;

        public ProductoServices()
        {
            _productos = _services.db.GetCollection<Producto>("Productos");
        }
        public async Task ActualizarProducto(Producto producto)
        {
            var product = Builders<Producto>.Filter.Eq(s=>s.Id, producto.Id);
            await _productos.ReplaceOneAsync(product,producto);
            
           
        }

        public async Task EliminarProducto(string id)
        {
           var product = Builders<Producto>.Filter.Eq("_id", new ObjectId(id));
            await _productos.DeleteOneAsync(product);
        }

        public async Task InsertarProducto(ProductoDto productoDto)
        {
            Producto producto = new Producto();
            producto.Cantidad = productoDto.Cantidad;
            producto.FechaIngreso = productoDto.FechaIngreso;
            producto.CategoriaId = productoDto.CategoriaId;
            producto.Nombre = productoDto.Nombre;
           await _productos.InsertOneAsync(producto);        }

        public async Task<List<Producto>> ObtenerProductos()
        {
            return await _productos.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Producto> ObtenerProductoPorId(string id)
        {
            return await _productos.FindAsync(new BsonDocument { { "_id", new ObjectId(id)} }).Result.FirstOrDefaultAsync();

        }
    }
}
