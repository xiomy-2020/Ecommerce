using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class VentaDto
    {
        public DateTime FechaVenta { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UsuarioId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductoId  { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string TiendaId { get; set; }
    }
}
