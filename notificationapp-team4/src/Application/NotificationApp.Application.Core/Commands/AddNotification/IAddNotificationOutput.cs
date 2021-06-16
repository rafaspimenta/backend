using System;

namespace NotificationApp.Application.Commands.AddNotification
{
    public interface IAddNotificationOutput
    {
        int NotificationId { get; }

        string Title { get; }

        string Url { get; }

        DateTime Date { get; }
    }
}
