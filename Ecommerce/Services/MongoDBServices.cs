using MongoDB.Driver;

namespace Ecommerce.Services
{
    public class MongoDBServices
    {
        public MongoClient client;
        public IMongoDatabase db;

        public MongoDBServices() 
        {
            client = new MongoClient("mongodb://127.0.0.1:27017");
            db = client.GetDatabase("EcommerceDB");
        }
    }
}
