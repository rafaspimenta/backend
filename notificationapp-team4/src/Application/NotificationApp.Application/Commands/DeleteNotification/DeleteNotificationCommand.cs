using System;
using System.Linq;

namespace NotificationApp.Application.Commands.DeleteNotification
{
    public class DeleteNotificationCommand : IDeleteNotiicationCommand
    {
        private readonly Domain.IChannelRepository channelRepository;

        public DeleteNotificationCommand(Domain.IChannelRepository channelRepository)
        {
            this.channelRepository = channelRepository;
        }

        public void Execute(IDeleteNotificationInput input)
        {
            var channel = this.channelRepository.Get(input.ChannelId);

            if (channel == null)
            {
                throw new InvalidOperationException($"Channel {input.ChannelId} not found.");
            }

            var notification = channel.Notifications.FirstOrDefault(f => f.Id == input.NotificationId);

            if (notification == null)
            {
                throw new InvalidOperationException($"Notification {input.NotificationId} not found.");
            }

            channel.Notifications.Remove(notification);

            this.channelRepository.Save(channel);
        }
    }
}
