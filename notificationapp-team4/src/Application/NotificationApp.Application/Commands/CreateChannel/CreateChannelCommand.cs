using FluentValidation;

namespace NotificationApp.Application.Commands.CreateChannel
{
    public class CreateChannelCommand : ICreateChannelCommand
    {
        private readonly Domain.IChannelRepository channelRepository;
        private readonly Domain.Models.IChannelFactory channelFactory;
        private readonly CreateChannelInputValidator inputValidator;

        public CreateChannelCommand(
            Domain.IChannelRepository channelRepository,
            Domain.Models.IChannelFactory channelFactory,
            CreateChannelInputValidator inputValidator)
        {
            this.channelRepository = channelRepository;
            this.channelFactory = channelFactory;
            this.inputValidator = inputValidator;
        }

        public ICreateChannelOutput Execute(ICreateChannelInput input)
        {
            this.inputValidator.ValidateAndThrow(input);

            var channel = this.channelFactory.Create();

            channel.Name = input.Name;

            this.channelRepository.Save(channel);

            return new CreateChannelOutput(channel.Id);
        }
    }
}
