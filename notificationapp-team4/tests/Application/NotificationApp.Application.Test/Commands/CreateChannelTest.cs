using Moq;
using NotificationApp.Application.Commands.CreateChannel;
using NotificationApp.Domain;
using Xunit;

namespace NotificationApp.Application.Test.Commands
{
    public class CreateChannelTest
    {
        private IChannelRepository GetChannelRepository()
        {
            var repositoryMock = new Mock<IChannelRepository>();
            repositoryMock
                .Setup(f => f.Save(It.IsAny<Domain.Models.IChannel>()));

            return repositoryMock.Object;
        }

        private Domain.Models.IChannelFactory GetChannelFactory()
        {
            var channelFactoryMock = new Mock<Domain.Models.IChannelFactory>();
            channelFactoryMock
                .Setup(f => f.Create())
                .Returns(Mock.Of<Domain.Models.IChannel>());

            return channelFactoryMock.Object;
        }

        [Fact]
        public void Given_NameEmpty_Wait_ValidationException()
        {
            var repositoryFactory = this.GetChannelRepository();
            var channelFactory = this.GetChannelFactory();

            var validator = new CreateChannelInputValidator();

            var command = new CreateChannelCommand(repositoryFactory, channelFactory, validator);

            var input = Mock.Of<ICreateChannelInput>();

            Assert.Throws<FluentValidation.ValidationException>(() => command.Execute(input));
        }
    }
}
