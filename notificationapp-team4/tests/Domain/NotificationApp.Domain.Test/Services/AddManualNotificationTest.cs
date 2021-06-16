using FluentAssertions;
using Moq;
using NotificationApp.Domain.Services.AddManualNotification;
using System;
using System.Collections.Generic;
using Xunit;

namespace NotificationApp.Domain.Test.Services
{
    public class AddManualNotificationTest
    {
        private IChannelRepository GetChannelRepository()
        {
            var repositoryMock = new Mock<IChannelRepository>();
            repositoryMock
                .Setup(f => f.Save(It.IsAny<Models.IChannel>()));

            repositoryMock
                .Setup(f => f.Get(It.Is<int>(value => value == 1)))
                .Returns(
                    Mock.Of<Models.IChannel>(f =>
                        f.Id == 1 &&
                        f.Name == "Channel 1" &&
                        f.Notifications == new List<Models.INotification>()));

            return repositoryMock.Object;
        }

        private Models.INotificationFactory GetNotificationFactory()
        {
            var notificationFactoryMock = new Mock<Models.INotificationFactory>();
            notificationFactoryMock
                .Setup(f => f.Create(It.IsAny<Models.IChannel>()))
                .Returns(new Func<Models.IChannel, Models.INotification>((channel) =>
                    Mock.Of<Models.INotification>(f => f.ChannelId == channel.Id)));

            return notificationFactoryMock.Object;
        }

        [Fact]
        public void Given_NotificationTitleEmpty_Wait_Untitled()
        {
            var repositoryFactory = this.GetChannelRepository();
            var notificationFactory = this.GetNotificationFactory();

            var service = new AddManualNotificationService(repositoryFactory, notificationFactory);

            var input = Mock.Of<IAddManualNotificationInput>(f =>
                f.ChannelId == 1 &&
                f.Url == "http://www.test.com");

            var output = service.Execute(input);

            output.Should().NotBeNull();
            output.Title.Should().Contain("untitled");
        }

        [Fact]
        public void Given_UnknownChanneld_Wait_Exception()
        {
            var repositoryFactory = this.GetChannelRepository();
            var notificationFactory = this.GetNotificationFactory();

            var service = new AddManualNotificationService(repositoryFactory, notificationFactory);

            var input = Mock.Of<IAddManualNotificationInput>(f =>
                f.ChannelId == 2 &&
                f.Url == "http://www.test.com");

            Assert.Throws<InvalidOperationException>(() => service.Execute(input));
        }
    }
}
