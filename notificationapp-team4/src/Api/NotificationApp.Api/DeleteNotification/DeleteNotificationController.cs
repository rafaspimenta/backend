using Microsoft.AspNetCore.Mvc;
using NotificationApp.Application.Commands.DeleteNotification;

namespace NotificationApp.Api.DeleteNotification
{
    [Route("api/channel")]
    [ApiController]
    public class DeleteNotificationController : ControllerBase
    {
        private readonly IUnitOfWorkProvider unitOfWorkProvider;
        private readonly IDeleteNotiicationCommand command;

        public DeleteNotificationController(
            IUnitOfWorkProvider unitOfWorkProvider,
            IDeleteNotiicationCommand command)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
            this.command = command;
        }

        [HttpDelete("{channelId}/notitication/{notificationId}")]
        public ActionResult Execute(
            int channelId,
            int notificationId)
        {
            var input = new DeleteNotificationInput
            {
                ChannelId = channelId,
                NotificationId = notificationId,
            };

            using (var uow = this.unitOfWorkProvider.Create())
            {
                try
                {
                    command.Execute(input);

                    uow.Commit();

                    return this.Accepted();
                }
                catch
                {
                    uow.Rollback();
                    throw;
                }
            }
        }
    }
}
