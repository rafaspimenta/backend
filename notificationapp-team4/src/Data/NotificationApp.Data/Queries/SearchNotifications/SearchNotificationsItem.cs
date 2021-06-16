using NotificationApp.Domain.Queries.SearchNotifications;
using System;

namespace NotificationApp.Data.Queries.SearchNotifications
{
    public class SearchNotificationsItem : ISearchNotificationsItem
    {
        public int ChannelId { get; set; }

        public int NotificationId { get; set; }

        public string ChannelName { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public DateTime Date { get; set; }
    }
}
