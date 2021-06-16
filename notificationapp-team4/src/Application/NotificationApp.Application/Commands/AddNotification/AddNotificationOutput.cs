using System;

namespace NotificationApp.Application.Commands.AddNotification
{
    internal class AddNotificationOutput : IAddNotificationOutput
    {
        private readonly Domain.Services.AddManualNotification.IAddManualNotificationOutput output;

        public AddNotificationOutput(Domain.Services.AddManualNotification.IAddManualNotificationOutput output)
        {
            this.output = output;
        }

        public int NotificationId => this.output.NotificationId;

        public string Title => this.output.Title;

        public string Url => this.output.Url;

        public DateTime Date => this.output.Date;
    }
}
