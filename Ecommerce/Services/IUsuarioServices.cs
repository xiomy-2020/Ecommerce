using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface IUsuarioServices
    {
        Task InsertarUsuario(UsuarioDto usuario);

        Task ActualizarUsuario(Usuario usuario);

        Task EliminarUsuario(string id);

        Task<List<Usuario>> ObtenerUsuarios();

        Task<Usuario> ObtenerUsuarioPorId(string id);
    }
}
