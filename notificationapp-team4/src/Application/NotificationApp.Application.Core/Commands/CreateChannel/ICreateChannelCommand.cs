namespace NotificationApp.Application.Commands.CreateChannel
{
    public interface ICreateChannelCommand
    {
        ICreateChannelOutput Execute(ICreateChannelInput input);
    }
}
