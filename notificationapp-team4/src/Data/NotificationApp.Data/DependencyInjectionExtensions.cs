using Microsoft.Extensions.DependencyInjection;

namespace NotificationApp.Data
{
    public static class DependencyInjectionExtensions
    {
        public static void AddData(this IServiceCollection services)
        {
            services.AddTransient<Domain.IChannelRepository, ChannelRepository>();
            services.AddTransient<IUnitOfWorkFactory, DbUnitOfWorkFactory>();
            services.AddTransient<Domain.Queries.SearchNotifications.ISearchNotificationsDataQuery, Queries.SearchNotifications.SearchNotificationsDataQuery>();
            services.AddTransient<Domain.Queries.SearchChannels.ISearchChannelsDataQuery, Queries.SearchChannels.SearchChannelsDataQuery>();
            services.AddScoped<IUnitOfWorkProvider, DbUnitOfWorkProvider>();
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        }
    }
}
