using Microsoft.Extensions.DependencyInjection;

namespace NotificationApp.Domain.Models
{
    public static class DependencyInjectionExtensions
    {
        public static void AddModels(this IServiceCollection services)
        {
            services.AddSingleton<IChannelFactory, ChannelFactory>();
            services.AddSingleton<INotificationFactory, NotificationFactory>();
        }
    }
}
