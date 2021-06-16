namespace NotificationApp.Application.Queries.SearchChannels
{
    public class SearchChannelsItem : ISearchChannelsItem
    {
        private readonly Domain.Queries.SearchChannels.ISearchChannelsItem item;

        public SearchChannelsItem(Domain.Queries.SearchChannels.ISearchChannelsItem item)
        {
            this.item = item;
        }

        public int ChannelId => this.item.ChannelId;

        public string Name => this.item.Name;

        public int NotificationsCount => this.item.NotificationsCount;
    }
}