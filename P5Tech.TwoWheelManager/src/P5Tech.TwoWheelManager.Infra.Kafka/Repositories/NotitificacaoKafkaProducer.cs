using Confluent.Kafka;
using Newtonsoft.Json;
using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Bases;
using P5Tech.TwoWheelManager.Domain.Queue;
using P5Tech.TwoWheelManager.Infra.Kafka.Configuration;

namespace P5Tech.TwoWheelManager.Infra.Kafka.Repositories
{
    public class NotitificacaoKafkaProducer(KafkaProducerConfiguration kafkaProducerConfig, IProducer<string, string> producer) : INotificacaoKafkaProducer
    {
        private readonly KafkaProducerConfiguration _kafkaProducerConfig = kafkaProducerConfig;
        private readonly IProducer<string, string> _producer = producer;

        public BaseResult<bool> Produce(Notificacao notificacao)
        {
            var json = JsonConvert.SerializeObject(notificacao, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            var result = _producer.ProduceAsync(_kafkaProducerConfig.TopicName, new Message<string, string> { Value = json }).GetAwaiter().GetResult();

            return result.Status switch
            {
                PersistenceStatus.NotPersisted => new BaseResult<bool>($"Send message status: {result.Status}"),
                PersistenceStatus.PossiblyPersisted or PersistenceStatus.Persisted => new BaseResult<bool> { Data = true },
                _ => new BaseResult<bool> { Data = true },
            };
        }
    }
}