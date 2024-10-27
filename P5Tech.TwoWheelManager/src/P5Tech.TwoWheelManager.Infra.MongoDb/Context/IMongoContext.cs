using MongoDB.Driver;
using P5Tech.TwoWheelManager.Infra.MongoDb.Collections;

namespace P5Tech.TwoWheelManager.Infra.MongoDb.Context
{
    public interface IMongoContext
    {
        IMongoCollection<MotoCollection> CollectionMotos { get; }
        IMongoCollection<EntregadorCollection> CollectionEntregadores { get; }
        IMongoCollection<LocacaoCollection> CollectionLocacoes { get; }
        IMongoCollection<PlanoLocacaoCollection> CollectionPlanoLocacoes { get; }
        IMongoCollection<MotoNotificacaoCollection> CollectionMotoNotificacoes { get; }
    }
}