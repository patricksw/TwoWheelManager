using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using P5Tech.TwoWheelManager.Domain.Bases;
using P5Tech.TwoWheelManager.Domain.Queue;
using P5Tech.TwoWheelManager.Infra.Kafka.Configuration;
using System;
using System.Threading;

namespace P5Tech.TwoWheelManager.Infra.Kafka.Repositories
{
    public class NotifficacaoKafkaConsumer : INotificacaoKafkaConsumer
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly KafkaConsumerConfiguration _kafkaConfiguration;

        public NotifficacaoKafkaConsumer(IOptions<KafkaConsumerConfiguration> options)
        {
            _kafkaConfiguration = options.Value;

            var consumerConfig = new ConsumerConfig
            {
                GroupId = _kafkaConfiguration.ConsumerGroup,
                BootstrapServers = _kafkaConfiguration.Server,
                AutoOffsetReset = _kafkaConfiguration.AutoOffsetReset,
                EnableAutoCommit = _kafkaConfiguration.EnableAutoCommit
            };

            _consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
            _consumer.Subscribe(_kafkaConfiguration.TopicName);
        }

        public BaseResult<T> Consume<T>(CancellationToken cancellationToken = default)
        {
            try
            {
                var consumeResult = _consumer.Consume(cancellationToken);

                var result = JsonConvert.DeserializeObject<T>(consumeResult.Message.Value);

                return new BaseResult<T>() { Data = result };
            }
            catch (ConsumeException ex)
            {
                return new BaseResult<T>("Consummer error", ex);
            }
            catch (JsonException ex)
            {
                return new BaseResult<T>("Parser json error", ex);
            }
            catch (Exception ex)
            {
                return new BaseResult<T>("Error", ex);
            }
        }

        public string GetSubscribe() => _kafkaConfiguration.TopicName;

        public void Dispose() => _consumer?.Close();

        public void Commit()
        {
            if (!_kafkaConfiguration.EnableAutoCommit)
                _consumer.Commit();
        }
    }
}
