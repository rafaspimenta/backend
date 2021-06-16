namespace NotificationApp.Domain.Models
{
    public class NotificationFactory : INotificationFactory
    {
        public INotification Create(IChannel channel)
        {
            return new Notification
            {
                ChannelId = channel.Id,
                Channel = (Channel)channel,
            };
        }
    }
}
