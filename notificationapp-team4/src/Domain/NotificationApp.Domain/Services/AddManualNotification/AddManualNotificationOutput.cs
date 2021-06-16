using System;

namespace NotificationApp.Domain.Services.AddManualNotification
{
    internal class AddManualNotificationOutput : IAddManualNotificationOutput
    {
        private readonly Models.INotification notification;

        public AddManualNotificationOutput(Models.INotification notification)
        {
            this.notification = notification;
        }

        public int NotificationId => this.notification.Id;

        public string Title => this.notification.Title;

        public string Url => this.notification.Url;

        public DateTime Date => this.notification.Date;
    }
}
