using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class ProductoDto
    {
        

        public string Nombre { get; set; }

        public int Cantidad { get; set; }

        public DateTime FechaIngreso { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoriaId { get; set; }       
        
    }
}
