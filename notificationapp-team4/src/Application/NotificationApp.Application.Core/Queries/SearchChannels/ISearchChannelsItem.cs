namespace NotificationApp.Application.Queries.SearchChannels
{
    public interface ISearchChannelsItem
    {
        int ChannelId { get; }

        string Name { get; }

        int NotificationsCount { get; }
    }
}