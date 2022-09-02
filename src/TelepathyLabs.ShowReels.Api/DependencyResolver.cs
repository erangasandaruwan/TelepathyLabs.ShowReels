using Microsoft.Extensions.DependencyInjection;
using TelepathyLabs.ShowReels.Api.Handler.ShowReels;
using TelepathyLabs.ShowReels.Api.Handler.VideoDefinitions;
using TelepathyLabs.ShowReels.Api.Handler.VideoStandards;
using TelepathyLabs.ShowReels.Core.Log;
using TelepathyLabs.ShowReels.Domain.Repository;
using TelepathyLabs.ShowReels.Domain.Service;

namespace TelepathyLabs.ShowReels.Api
{
    public static class DependencyResolver
    {
        public static IServiceCollection ConfigureLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            return services;
        }

        public static IServiceCollection ConfigureHandlers(this IServiceCollection services)
        {
            // Handlers
            services.AddTransient<IShowReelCreateHandler, ShowReelCreateHandler>();
            services.AddTransient<IShowReelGetHandler, ShowReelGetHandler>();
            services.AddTransient<IVideoDefinitionGetHandler, VideoDefinitionGetHandler>();
            services.AddTransient<IVideoStandardGetHandler, VideoStandardGetHandler>();

            return services;
        }

        public static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
        {            
            // Services
            services.AddTransient<IShowReelService, ShowReelService>();
            services.AddTransient<IVideoDefinitionService, VideoDefinitionService>();
            services.AddTransient<IVideoStandardService, VideoStandardService>();

            return services;
        }

        public static IServiceCollection ConfigureRepositores(this IServiceCollection services)
        {
            // Repos
            services.AddTransient<IShowReelRepository, ShowReelRepository>();

            return services;
        }
    }
}
