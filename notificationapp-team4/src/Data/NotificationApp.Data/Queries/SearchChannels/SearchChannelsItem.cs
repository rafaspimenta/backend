using NotificationApp.Domain.Queries.SearchChannels;

namespace NotificationApp.Data.Queries.SearchChannels
{
    public class SearchChannelsItem : ISearchChannelsItem
    {
        public int ChannelId { get; set; }

        public string Name { get; set; }

        public int NotificationsCount { get; set; }
    }
}
