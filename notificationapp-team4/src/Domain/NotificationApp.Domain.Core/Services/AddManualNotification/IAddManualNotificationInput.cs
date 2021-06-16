namespace NotificationApp.Domain.Services.AddManualNotification
{
    public interface IAddManualNotificationInput
    {
        int ChannelId { get; }

        string Title { get; }

        string Url { get; }
    }
}
