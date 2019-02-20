using ChatHub.AppService.LoginModule;
using ChatHub.AppService.LoginModule.Services;
using ChatHub.AppService.MessengerModule;
using ChatHub.AppService.MessengerModule.Services;
using ChatHub.DomainService;
using ChatHub.DomainService.EFContext;
using ChatHub.DomainService.MessageRooms;
using ChatHub.DomainService.Messages;
using ChatHub.DomainService.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatHub.Application.Infrastructure
{
    public static class DependencyResolverExtentions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMessengerModule, MessengerModule>();
            services.AddTransient<ILoginModule, LoginModule>();
        }

        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<ChatHubEntities, ChatHubEntities>();

            services.AddTransient<IDataContext, DataContext>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IMessageRoomService, MessageRoomService>();
        }
    }
}
