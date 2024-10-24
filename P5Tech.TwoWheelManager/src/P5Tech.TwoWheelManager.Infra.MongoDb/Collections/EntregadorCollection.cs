using P5Tech.TwoWheelManager.Infra.MongoDb.Bases;
using System;

namespace P5Tech.TwoWheelManager.Infra.MongoDb.Collections
{
    public class EntregadorCollection : BaseCollection
    {
        public string Identificador { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroCnh { get; set; }
        public string TipoCnh { get; set; }
        public string ImagemCnh { get; set; }
    }
}