using Ecommerce.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ecommerce.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        internal MongoDBServices _services = new MongoDBServices();

        private IMongoCollection<Usuario> _users;

        public UsuarioServices() 
        {
            _users = _services.db.GetCollection<Usuario>("Usuarios");
        }

        public async Task ActualizarUsuario(Usuario usuario)
        {
            var user = Builders<Usuario>.Filter.Eq(s => s.Id, usuario.Id);
            await _users.ReplaceOneAsync(user, usuario);
        }

        public async Task EliminarUsuario(string id)
        {
            var user = Builders<Usuario>.Filter.Eq("_id",new ObjectId(id));
            await _users.DeleteOneAsync(user);
        }

        public async Task InsertarUsuario(UsuarioDto usuarioDto)
        {
            Usuario usuario = new Usuario();
            usuario.Cedula = usuarioDto.Cedula;
            usuario.Correo = usuarioDto.Correo;
            usuario.Nombre = usuarioDto.Nombre;
            usuario.TiendaId = usuarioDto.TiendaId;
            usuario.Direccion = usuarioDto.Direccion;
            await _users.InsertOneAsync(usuario);
        }

        public async Task<Usuario> ObtenerUsuarioPorId(string id)
        {
            return await _users.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstOrDefaultAsync();
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            return await _users.FindAsync(new BsonDocument()).Result.ToListAsync();
        }      
    }
}
