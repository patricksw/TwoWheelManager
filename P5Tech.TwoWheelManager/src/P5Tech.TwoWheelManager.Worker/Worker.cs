using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Queue;
using P5Tech.TwoWheelManager.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Worker
{
    public class Worker(INotificacaoKafkaConsumer notificacaoKafkaConsumer,
                        IMotoNotificacaoService motoNotificacaoService,
                        ILogger<Worker> logger) : BackgroundService
    {
        private readonly ILogger<Worker> _logger = logger;
        private readonly INotificacaoKafkaConsumer _notificacaoKafkaConsumer = notificacaoKafkaConsumer;
        private readonly IMotoNotificacaoService _motoNotificacaoService = motoNotificacaoService;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Iniciando Worker..");

            while (!stoppingToken.IsCancellationRequested)
            {
                using (_logger.BeginScope("{CorrelationId}", Guid.NewGuid().ToString()))
                {
                    try
                    {
                        var result = _notificacaoKafkaConsumer.Consume<Notificacao>(stoppingToken);

                        _logger.LogInformation("Consummer {Notificacao}", result.Data.Value);

                        await _motoNotificacaoService.Consummer(result.Data.GetValue<Moto>());

                        _notificacaoKafkaConsumer.Commit();

                        await Task.Delay(1000, stoppingToken);
                    }
                    catch
                    {
                        await ExecuteAsync(stoppingToken);
                    }
                }
            }
        }
    }
}