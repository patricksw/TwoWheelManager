using Microsoft.Extensions.Hosting;
using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Queue;
using P5Tech.TwoWheelManager.Domain.Services;
using System.Threading;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Worker
{
    public class Worker(INotificacaoKafkaConsumer notificacaoKafkaConsumer,
                        IMotoNotificacaoService motoNotificacaoService) : BackgroundService
    {
        private readonly INotificacaoKafkaConsumer _notificacaoKafkaConsumer = notificacaoKafkaConsumer;
        private readonly IMotoNotificacaoService _motoNotificacaoService = motoNotificacaoService;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    //
            //    await Task.Delay(1000, stoppingToken);
            //}
            try
            {
                var result = _notificacaoKafkaConsumer.Consume<Notificacao>(stoppingToken);

                await _motoNotificacaoService.Consummer(result.Data.Value as Moto);

                await Task.Delay(1000, stoppingToken);
            }
            catch
            {
                await ExecuteAsync(stoppingToken);
            }
        }
    }
}