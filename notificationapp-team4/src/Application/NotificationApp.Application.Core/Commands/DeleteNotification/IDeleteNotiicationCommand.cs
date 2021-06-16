namespace NotificationApp.Application.Commands.DeleteNotification
{
    public interface IDeleteNotiicationCommand
    {
        void Execute(IDeleteNotificationInput input);
    }
}
