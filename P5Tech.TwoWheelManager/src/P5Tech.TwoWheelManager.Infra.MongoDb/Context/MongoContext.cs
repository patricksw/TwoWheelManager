using Microsoft.Extensions.Options;
using MongoDB.Driver;
using P5Tech.TwoWheelManager.Infra.MongoDb.Collections;
using P5Tech.TwoWheelManager.Infra.MongoDb.Configuration;

namespace P5Tech.TwoWheelManager.Infra.MongoDb.Context
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _db;

        public MongoContext(IOptions<MongoDbConfiguration> options)
        {
            var mongoConfiguration = options.Value;
            var client = new MongoClient(mongoConfiguration.GetSampleStringConnection());
            _db = client.GetDatabase(mongoConfiguration.DataBaseName);
        }

        public IMongoCollection<MotoCollection> CollectionMotos => _db.GetCollection<MotoCollection>("Moto");
    }
}