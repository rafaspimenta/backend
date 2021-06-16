using Microsoft.AspNetCore.Mvc;
using NotificationApp.Application.Commands.AddNotification;

namespace NotificationApp.Api.AddNotification
{
    [Route("api/channel")]
    [ApiController]
    public class AddNotificationController : ControllerBase
    {
        private readonly IUnitOfWorkProvider unitOfWorkProvider;
        private readonly IAddNotificationCommand command;

        public AddNotificationController(
            IUnitOfWorkProvider unitOfWorkProvider,
            IAddNotificationCommand command)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
            this.command = command;
        }

        [HttpPost("{channelId}/notitication")]
        public ActionResult<IAddNotificationOutput> Post(
            int channelId,
            [FromBody] AddNotificationInput input)
        {
            input.ChannelId = channelId;

            using (var uow = this.unitOfWorkProvider.Create())
            {
                try
                {
                    var output = command.Execute(input);

                    uow.Commit();

                    return new ActionResult<IAddNotificationOutput>(output);
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
