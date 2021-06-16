namespace NotificationApp.Application.Commands.CreateChannel
{
    internal class CreateChannelOutput : ICreateChannelOutput
    {
        public CreateChannelOutput(int channelId)
        {
            this.ChannelId = channelId;
        }

        public int ChannelId { get; }
    }
}
