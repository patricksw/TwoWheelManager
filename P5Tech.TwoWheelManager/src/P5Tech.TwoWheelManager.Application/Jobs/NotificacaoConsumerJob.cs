using P5Tech.TwoWheelManager.Domain.Queue;
using P5Tech.TwoWheelManager.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Application.Jobs
{
    public class NotificacaoConsumerJob
    {
        //private readonly ILogger<NotificacaoConsumerJob> _logger;
        private readonly INotificacaoKafkaConsumer _kafkaTrackingConsumer;
        private readonly IMotoService _motoService;

        public NotificacaoConsumerJob(INotificacaoKafkaConsumer consummer, IMotoService motoService)
        {
            // _logger = logger;
            _kafkaTrackingConsumer = consummer;
            _motoService = motoService;
        }

        public async Task ProcessTrackingKafka(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await ConsumeTrackingKafkaMessage(stoppingToken);
                }
                catch (Exception ex)
                {
                    //_logger.LogarErro(ex, "{App} -> Erro ao consumir ou processar mensagem tracking offline.");
                }
            }
        }

        public async Task ConsumeTrackingKafkaMessage(CancellationToken stoppingToken)
        {
            //using (_logger.BeginScope("{CorrelationId}", Guid.NewGuid().ToString()))
            //var result = _kafkaTrackingConsumer.Consume<TrackingExternalMessage>(stoppingToken);

            //if (!result.Valido)
            //{
            //    _logger.LogarErro(result?.Erro, result?.Mensagens, null);
            //    _kafkaTrackingConsumer.Commit();
            //    return;
            //}

            //var trackingMessage = result.Data;
            //var validator = new TrackingExternalMessageValidator();

            //var validationResult = validator.Validate(trackingMessage);
            //if (validationResult.IsValid)
            //{
            //    var tracking = trackingMessage.ItemTrackingExternalMessage;
            //    await _trackingManagerService.Process(tracking);
            //}

            //_kafkaTrackingConsumer.Commit();
        }
    }
}