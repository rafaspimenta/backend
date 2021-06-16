namespace NotificationApp.Application.Commands.AddNotification
{
    public interface IAddNotificationCommand
    {
        IAddNotificationOutput Execute(IAddNotificationInput input);
    }
}
