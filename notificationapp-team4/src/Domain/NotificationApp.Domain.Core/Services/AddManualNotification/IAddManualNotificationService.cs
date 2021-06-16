namespace NotificationApp.Domain.Services.AddManualNotification
{
    public interface IAddManualNotificationService
    {
        IAddManualNotificationOutput Execute(IAddManualNotificationInput input);
    }
}
