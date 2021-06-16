namespace NotificationApp.Domain.Models
{
    public interface INotificationFactory
    {
        INotification Create(IChannel channel);
    }
}
