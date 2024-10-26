using Confluent.Kafka;
using P5Tech.TwoWheelManager.Infra.Kafka.Bases;

namespace P5Tech.TwoWheelManager.Infra.Kafka.Configuration
{
    public class KafkaConsumerConfiguration : BaseKafkaConfiguration
    {
        public string ConsumerGroup { get; set; }
        public AutoOffsetReset AutoOffsetReset { get; set; }
        public bool EnableAutoCommit { get; set; }
    }
}