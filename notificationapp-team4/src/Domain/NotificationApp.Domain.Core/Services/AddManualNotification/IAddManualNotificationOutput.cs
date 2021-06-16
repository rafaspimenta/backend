using System;

namespace NotificationApp.Domain.Services.AddManualNotification
{
    public interface IAddManualNotificationOutput
    {
        int NotificationId { get; }

        string Title { get; }

        string Url { get; }

        DateTime Date { get; }
    }
}
