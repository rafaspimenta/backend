using System;

namespace NotificationApp.Domain.Queries.SearchNotifications
{
    public interface ISearchNotificationsInput
    {
        int? ChannelId { get; }
    }
}
