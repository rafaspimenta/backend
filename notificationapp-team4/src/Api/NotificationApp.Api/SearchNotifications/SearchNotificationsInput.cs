using NotificationApp.Application.Queries.SearchNotifications;

namespace NotificationApp.Api.SearchNotifications
{
    internal class SearchNotificationsInput : ISearchNotificationsInput
    {
        public int? ChannelId { get; set; }
    }
}
