using P5Tech.TwoWheelManager.Infra.MongoDb.Bases;

namespace P5Tech.TwoWheelManager.Infra.MongoDb.Collections
{
    public class PlanoLocacaoCollection : BaseCollection
    {
        public int Plano { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}