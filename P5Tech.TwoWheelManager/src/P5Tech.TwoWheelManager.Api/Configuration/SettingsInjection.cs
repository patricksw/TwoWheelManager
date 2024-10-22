using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using P5Tech.TwoWheelManager.Infra.MongoDb.Collections;
using P5Tech.TwoWheelManager.Infra.MongoDb.Configuration;

namespace P5Tech.TwoWheelManager.Api.Configuration
{
    public static class SettingsInjection
    {
        public static IServiceCollection DeclareConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            MongoDbConfiguration mongoSetting = configuration.GetSection("MongoDbConnection").Get<MongoDbConfiguration>();
            var pack = new ConventionPack
            {
                new EnumRepresentationConvention(BsonType.String)
            };
            ConventionRegistry.Register("EnumStringConvention", pack, t => true);

            services.AddScoped(_ => new MongoClient(mongoSetting.GetSampleStringConnection())
                    .GetDatabase(mongoSetting.DataBaseName)
                    .GetCollection<MotoCollection>("Moto"));

            services.AddSingleton<IGridFSBucket>(new GridFSBucket(new MongoClient(mongoSetting.GetSampleStringConnection()).GetDatabase(mongoSetting.DataBaseName)));

            return services;
        }
    }
}