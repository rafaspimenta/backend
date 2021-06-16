using System;

namespace NotificationApp.Domain.Queries.SearchNotifications
{
    public interface ISearchNotificationsItem
    {
        int ChannelId { get; }

        int NotificationId { get; }

        string ChannelName { get; }

        string Title { get; }

        string Url { get; }

        DateTime Date { get; }
    }
}
