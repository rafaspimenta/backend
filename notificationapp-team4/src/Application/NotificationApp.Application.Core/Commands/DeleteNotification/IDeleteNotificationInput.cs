namespace NotificationApp.Application.Commands.DeleteNotification
{
    public interface IDeleteNotificationInput
    {
        int ChannelId { get; }

        int NotificationId { get; }
    }
}
