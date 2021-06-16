using NotificationApp.Application.Commands.DeleteNotification;

namespace NotificationApp.Api.DeleteNotification
{
    public class DeleteNotificationInput : IDeleteNotificationInput
    {
        public int ChannelId { get; set; }

        public int NotificationId { get; set; }
    }
}
