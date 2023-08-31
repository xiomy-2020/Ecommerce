using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecommerce.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Cedula { get; set; }

        public string Correo { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string TiendaId { get; set; }
    }
}
