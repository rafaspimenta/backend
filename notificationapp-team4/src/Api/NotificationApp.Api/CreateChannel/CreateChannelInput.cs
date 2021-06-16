using NotificationApp.Application.Commands.CreateChannel;

namespace NotificationApp.Api.CreateChannel
{
    public class CreateChannelInput : ICreateChannelInput
    {
        public string Name { get; set; }
    }
}