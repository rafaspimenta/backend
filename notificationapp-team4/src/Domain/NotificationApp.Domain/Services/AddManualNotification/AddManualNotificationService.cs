using System;

namespace NotificationApp.Domain.Services.AddManualNotification
{
    public class AddManualNotificationService : IAddManualNotificationService
    {
        private readonly IChannelRepository channelRepository;
        private readonly Models.INotificationFactory notificationFactory;

        public AddManualNotificationService(
            IChannelRepository channelRepository,
            Models.INotificationFactory notificationFactory)
        {
            this.channelRepository = channelRepository;
            this.notificationFactory = notificationFactory;
        }

        private void Apply(IAddManualNotificationInput input, Models.INotification notification)
        {
            notification.Title = string.IsNullOrEmpty(input.Title) ? "untitled" : input.Title;
            notification.Url = input.Url;
        }

        public IAddManualNotificationOutput Execute(IAddManualNotificationInput input)
        {
            var channel = this.channelRepository.Get(input.ChannelId);

            if (channel == null)
            {
                throw new InvalidOperationException($"Channel '{input.ChannelId}' not found.");
            }

            var notification = this.notificationFactory.Create(channel);
            this.Apply(input, notification);

            channel.Notifications.Add(notification);

            this.channelRepository.Save(channel);

            return new AddManualNotificationOutput(notification);
        }
    }
}
