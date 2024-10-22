using P5Tech.TwoWheelManager.Infra.MongoDb.Bases;

namespace P5Tech.TwoWheelManager.Infra.MongoDb.Collections
{
    public class MotoCollection : BaseCollection
    {
        public string Identificador { get; set; }
        public string Ano { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
    }
}