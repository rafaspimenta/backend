namespace NotificationApp.Application.Commands.AddNotification
{
    public class AddNotificationCommand : IAddNotificationCommand
    {
        private readonly Domain.Services.AddManualNotification.IAddManualNotificationService service;

        public AddNotificationCommand(
            Domain.Services.AddManualNotification.IAddManualNotificationService service)
        {
            this.service = service;
        }

        public IAddNotificationOutput Execute(IAddNotificationInput input)
        {
            var output = this.service.Execute(new Input(input));

            return new AddNotificationOutput(output);
        }

        private class Input : Domain.Services.AddManualNotification.IAddManualNotificationInput
        {
            private readonly IAddNotificationInput input;

            public Input(IAddNotificationInput input)
            {
                this.input = input;
            }

            public int ChannelId => this.input.ChannelId;

            public string Title => this.input.Title;

            public string Url => this.input.Url;
        }
    }
}
