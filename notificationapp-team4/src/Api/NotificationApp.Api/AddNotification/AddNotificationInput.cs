using NotificationApp.Application.Commands.AddNotification;

namespace NotificationApp.Api.AddNotification
{
    public class AddNotificationInput : IAddNotificationInput
    {
        internal int ChannelId { get; set; }

        int IAddNotificationInput.ChannelId => this.ChannelId;

        public string Title { get; set; }

        public string Url { get; set; }
    }
}
