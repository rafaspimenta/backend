namespace NotificationApp.Domain.Models
{
    public class ChannelFactory : IChannelFactory
    {
        public IChannel Create()
        {
            return new Channel();
        }
    }
}
