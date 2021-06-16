using Microsoft.Extensions.DependencyInjection;

namespace NotificationApp.Application
{
    public static class DependencyInjectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<Commands.CreateChannel.ICreateChannelCommand, Commands.CreateChannel.CreateChannelCommand>();
            services.AddTransient<Commands.CreateChannel.CreateChannelInputValidator>();
            services.AddTransient<Queries.SearchNotifications.ISearchNotificationsQuery, Queries.SearchNotifications.SearchNotificationsQuery>();
            services.AddTransient<Commands.AddNotification.IAddNotificationCommand, Commands.AddNotification.AddNotificationCommand>();
            services.AddTransient<Commands.DeleteNotification.IDeleteNotiicationCommand, Commands.DeleteNotification.DeleteNotificationCommand>();
            services.AddTransient<Queries.SearchChannels.ISearchChannelsQuery, Queries.SearchChannels.SearchChannelsQuery>();
        }
    }
}
