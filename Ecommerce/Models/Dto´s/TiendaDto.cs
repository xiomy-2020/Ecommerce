using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class TiendaDto
    {
      

        public string Nombre { get; set; }

        public string Nit { get; set; }
        
    }
}
