using Microsoft.Extensions.DependencyInjection;
using TelepathyLabs.ShowReels.Api.Handler.ShowReels;
using TelepathyLabs.ShowReels.Api.Handler.VideoDefinitions;
using TelepathyLabs.ShowReels.Api.Handler.VideoStandards;
using TelepathyLabs.ShowReels.Domain.Repository;
using TelepathyLabs.ShowReels.Domain.Service;

namespace TelepathyLabs.ShowReels.Api
{
    public static class DependencyResolver
    {
        public static IServiceCollection ConfigureShowReelDomain(this IServiceCollection services)
        {
            services.AddTransient<IShowReelService, ShowReelService>();
            services.AddTransient<IVideoDefinitionService, VideoDefinitionService>();
            services.AddTransient<IVideoStandardService, VideoStandardService>();

            services.AddTransient<IShowReelRepository, ShowReelRepository>();

            services.AddTransient<IShowReelCreateHandler, ShowReelCreateHandler>();
            services.AddTransient<IShowReelGetHandler, ShowReelGetHandler>();
            services.AddTransient<IVideoDefinitionGetHandler, VideoDefinitionGetHandler>();
            services.AddTransient<IVideoStandardGetHandler, VideoStandardGetHandler>();

            return services;
        }
    }
}
