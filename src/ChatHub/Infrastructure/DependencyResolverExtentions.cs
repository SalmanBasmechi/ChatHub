using ChatHub.Data.EFContext;
using Microsoft.Extensions.DependencyInjection;

namespace ChatHub.Infrastructure
{
    public static class DependencyResolverExtentions
    {
        public static void AddDataService(this IServiceCollection services)
        {
            services.AddDbContext<ChatHubEntities>(ServiceLifetime.Scoped);
        }
    }
}
