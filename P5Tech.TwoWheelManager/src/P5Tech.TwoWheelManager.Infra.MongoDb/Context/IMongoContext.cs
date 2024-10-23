using MongoDB.Driver;
using P5Tech.TwoWheelManager.Infra.MongoDb.Collections;

namespace P5Tech.TwoWheelManager.Infra.MongoDb.Context
{
    public interface IMongoContext
    {
        IMongoCollection<MotoCollection> CollectionMotos { get; }
    }
}