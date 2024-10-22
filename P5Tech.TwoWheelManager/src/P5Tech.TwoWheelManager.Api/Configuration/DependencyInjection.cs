using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using P5Tech.TwoWheelManager.Application.Interfaces;
using P5Tech.TwoWheelManager.Application.Services;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Infra.MongoDb.Repositories;

namespace P5Tech.TwoWheelManager.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection DeclareServices(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            services
                .AddSingleton(config)
                //repositories
                .AddScoped<IMotoRepository, MotoRepository>()
                //services
                .AddScoped<IMotoService, MotoService>()
                .AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}