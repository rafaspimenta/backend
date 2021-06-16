using Microsoft.Extensions.DependencyInjection;

namespace NotificationApp.Domain
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddTransient<Services.AddManualNotification.IAddManualNotificationService, Services.AddManualNotification.AddManualNotificationService>();
        }
    }
}
