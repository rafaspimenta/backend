namespace NotificationApp.Application.Commands.AddNotification
{
    public interface IAddNotificationInput
    {
        int ChannelId { get; }

        string Title { get; }

        string Url { get; }
    }
}
