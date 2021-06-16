using FluentValidation;

namespace NotificationApp.Application.Commands.CreateChannel
{
    public class CreateChannelInputValidator : AbstractValidator<ICreateChannelInput>
    {
        public CreateChannelInputValidator()
        {
            this.RuleFor(f => f.Name)
                .NotEmpty();
        }
    }
}
