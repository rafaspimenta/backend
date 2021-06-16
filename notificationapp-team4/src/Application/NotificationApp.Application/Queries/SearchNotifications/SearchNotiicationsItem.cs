using System;

namespace NotificationApp.Application.Queries.SearchNotifications
{
    internal class SearchNotiicationsItem : ISearchNotificationsItem
    {
        private readonly Domain.Queries.SearchNotifications.ISearchNotificationsItem item;

        public SearchNotiicationsItem(Domain.Queries.SearchNotifications.ISearchNotificationsItem item)
        {
            this.item = item;
        }

        public int ChannelId => this.item.ChannelId;

        public int NotificationId => this.item.NotificationId;

        public string ChannelName => this.item.ChannelName;

        public string Title => this.item.Title;

        public string Url => this.item.Url;

        public DateTime Date => this.item.Date;
    }
}
