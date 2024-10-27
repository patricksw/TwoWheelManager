using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using P5Tech.TwoWheelManager.Application.MotoConcept.Services;
using P5Tech.TwoWheelManager.Domain.Queue;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Domain.Services;
using P5Tech.TwoWheelManager.Infra.Kafka.Configuration;
using P5Tech.TwoWheelManager.Infra.Kafka.Repositories;
using P5Tech.TwoWheelManager.Infra.MongoDb.Configuration;
using P5Tech.TwoWheelManager.Infra.MongoDb.Context;
using P5Tech.TwoWheelManager.Infra.MongoDb.Repositories;
using Serilog;

namespace P5Tech.TwoWheelManager.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args);

            builder.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                   .ReadFrom.Configuration(hostingContext.Configuration)
                   .WriteTo.Console());

            builder.Build()
                   .Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    var config = TypeAdapterConfig.GlobalSettings;

                    services.AddSingleton(config);

                    services.Configure<KafkaConsumerConfiguration>(configuration.GetSection("KafkaConsumer"));
                    services.Configure<MongoDbConfiguration>(configuration.GetSection("MongoDbConnection"));

                    //repositories
                    services.AddSingleton<IMotoNotificacaoRepository, MotoNotificacaoRepository>();
                    services.AddSingleton<INotificacaoKafkaConsumer, NotifficacaoKafkaConsumer>();
                    services.AddSingleton<IMongoContext, MongoContext>();

                    //services
                    services.AddSingleton<IMotoNotificacaoService, MotoNotificacaoService>();
                    services.AddSingleton<IMapper, ServiceMapper>();
                    services.AddHostedService<Worker>();
                });
    }
}