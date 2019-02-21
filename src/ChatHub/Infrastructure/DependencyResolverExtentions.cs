using ChatHub.Data;
using ChatHub.Data.EFContext;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatHub.Infrastructure
{
    public static class DependencyResolverExtentions
    {
        public static void AddDataService(this IServiceCollection services)
        {
            services.AddTransient<ChatHubEntities, ChatHubEntities>();
        }
    }
}
