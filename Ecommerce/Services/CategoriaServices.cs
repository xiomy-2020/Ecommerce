using Ecommerce.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ecommerce.Services
{
    public class CategoriaServices : ICategoriaServices
    {
        internal MongoDBServices _services = new MongoDBServices();

        private IMongoCollection<Categoria> categoriaCollection;


        public CategoriaServices()
        {
            categoriaCollection = _services.db.GetCollection<Categoria>("Categorias");
        }
        public async Task ActualizarCategoria(Categoria categoria)
        {
            var category = Builders<Categoria>.Filter.Eq(s => s.Nombre, categoria.Nombre);
            await categoriaCollection.ReplaceOneAsync(category, categoria);
        }

        public async Task EliminarCategoria(string id)
        {
            var category = Builders<Categoria>.Filter.Eq("_id",new ObjectId(id));
            await categoriaCollection.DeleteOneAsync(category);
        }

        public async Task InsertarCategoria(CategoriaDto categoriaDto)
        {
            Categoria categoria = new Categoria();
            categoria.Nombre = categoriaDto.Nombre;
            await categoriaCollection.InsertOneAsync(categoria);
        }

        public async Task<List<Categoria>> ObtenerCategorias()
        {
            return await categoriaCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Categoria> ObtenerCategoriaPorId(string id)
        {
            return await categoriaCollection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstOrDefaultAsync();

        }

       
    }
}
