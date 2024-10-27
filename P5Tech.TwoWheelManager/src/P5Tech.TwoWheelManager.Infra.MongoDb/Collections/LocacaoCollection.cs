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

        public DateOnly DataInicio { get; set; }
        public DateOnly? DataTermino { get; set; }
        public DateOnly? DataPrevisaoTermino { get; set; }
        public DateOnly? DataDevolucao { get; set; }
        public int Plano { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}