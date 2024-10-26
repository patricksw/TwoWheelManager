using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using P5Tech.TwoWheelManager.Infra.MongoDb.Bases;
using System;

namespace P5Tech.TwoWheelManager.Infra.MongoDb.Collections
{
    public class LocacaoCollection : BaseCollection
    {
        [BsonRepresentation(BsonType.String)]
        public Guid EntregadorId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid MotoId { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public DateTime? DataPrevisaoTermino { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int Plano { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}