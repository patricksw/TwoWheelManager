using P5Tech.TwoWheelManager.CrossCutting.Extensions;
using System.Collections.Generic;

namespace P5Tech.TwoWheelManager.Infra.MongoDb.Configuration
{
    public class MongoDbConfiguration
    {
        public string User { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> ListServersReplicaSet { get; set; }
        public string DataBaseName { get; set; }
        public bool UseSsl { get; set; }
        public string Server { get; set; }
        public string ReplicaSet { get; set; }

        public string GetSampleStringConnection() =>
            string.Format("mongodb://{0}/{1}",
                           Server,
                           DataBaseName);

        public string GetReplicasetStringConnection() =>
            string.Format("mongodb://{0}:{1}@{2}/{3}?ssl={4}&replicaSet={5}&authSource=admin&retryWrites=true&w=majority",
                           User,
                           Password,
                           ListServersReplicaSet.ToJson(),
                           DataBaseName,
                           UseSsl,
                           ReplicaSet);
    }
}