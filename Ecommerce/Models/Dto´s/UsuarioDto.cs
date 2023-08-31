using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecommerce.Models
{
    public class UsuarioDto
    {
       

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Cedula { get; set; }

        public string Correo { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string TiendaId { get; set; }
    }
}
