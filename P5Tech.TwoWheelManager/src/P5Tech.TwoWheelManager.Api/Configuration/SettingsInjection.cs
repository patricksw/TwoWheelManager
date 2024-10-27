using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using P5Tech.TwoWheelManager.Infra.File.LocalDiskFile;
using P5Tech.TwoWheelManager.Infra.Kafka.Configuration;
using P5Tech.TwoWheelManager.Infra.MongoDb.Configuration;
using P5Tech.TwoWheelManager.Infra.MongoDb.Context;
using System.Reflection;

namespace P5Tech.TwoWheelManager.Api.Configuration
{
    public static class SettingsInjection
    {
        public static IServiceCollection DeclareConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var directory = $"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\files";

            if (!System.IO.Directory.Exists(directory))
                System.IO.Directory.CreateDirectory(directory);

            services.Configure<MongoDbConfiguration>(configuration.GetSection("MongoDbConnection"));
            services.ConfigureProducer(configuration);

            services.AddSingleton<IMongoContext, MongoContext>();
            services.AddSingleton(new LocalDiskImage(directory) as ILocalDiskImage);

            var pack = new ConventionPack
            {
                new EnumRepresentationConvention(BsonType.String)
            };
            ConventionRegistry.Register("EnumStringConvention", pack, t => true);

            return services;
        }

        public static void ConfigureProducer(this IServiceCollection services, IConfiguration configuration)
        {
            KafkaProducerConfiguration kafkaProducer = configuration.GetSection("KafkaProducer").Get<KafkaProducerConfiguration>();

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = kafkaProducer.Server,
                Acks = Acks.None
            };

            var producer = new ProducerBuilder<string, string>(producerConfig).SetValueSerializer(Serializers.Utf8).Build();

            services.AddSingleton(kafkaProducer);
            services.AddSingleton(producer);
        }
    }
}