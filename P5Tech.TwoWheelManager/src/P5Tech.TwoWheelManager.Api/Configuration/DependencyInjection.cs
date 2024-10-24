using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using P5Tech.TwoWheelManager.Application.EntregadorConcept.Services;
using P5Tech.TwoWheelManager.Application.MotoConcept.Services;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Domain.Services;
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
                .AddScoped<IEntregadorRepository, EntregadorRepository>()
                .AddScoped<ILocacaoRepository, LocacaoRepository>()
                //services
                .AddScoped<IMotoService, MotoService>()
                .AddScoped<IEntregadorService, EntregadorService>()
                .AddScoped<ILocacaoService, LocacaoService>()
                .AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}