using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using P5Tech.TwoWheelManager.Application.MotoConcept.Services;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Domain.Services;
using P5Tech.TwoWheelManager.Infra.Kafka.Configuration;
using P5Tech.TwoWheelManager.Infra.MongoDb.Configuration;
using P5Tech.TwoWheelManager.Infra.MongoDb.Repositories;

namespace P5Tech.TwoWheelManager.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args);

            builder.Build()
                   .Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    services.Configure<KafkaConsumerConfiguration>(configuration.GetSection("KafkaConsumer"));
                    services.Configure<MongoDbConfiguration>(configuration.GetSection("MongoDbConnection"));

                    //repositories
                    services.AddTransient<IMotoNotificacaoRepository, MotoNotificacaoRepository>();

                    //services
                    services.AddTransient<IMotoNotificacaoService, MotoNotificacaoService>();
                    services.AddHostedService<Worker>();
                });
    }
}