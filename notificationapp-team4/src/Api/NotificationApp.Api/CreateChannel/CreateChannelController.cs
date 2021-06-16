using Microsoft.AspNetCore.Mvc;
using NotificationApp.Application.Commands.CreateChannel;

namespace NotificationApp.Api.CreateChannel
{
    [Route("api/channel")]
    [ApiController]
    public class CreateChannelController : ControllerBase
    {
        private readonly IUnitOfWorkProvider unitOfWorkProvider;
        private readonly ICreateChannelCommand command;

        public CreateChannelController(
            IUnitOfWorkProvider unitOfWorkProvider,
            ICreateChannelCommand command)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
            this.command = command;
        }

        [HttpPost]
        public IActionResult Post(
            [FromBody] CreateChannelInput input)
        {
            using (var uow = this.unitOfWorkProvider.Create())
            {
                try
                {
                    var output = this.command.Execute(input);

                    uow.Commit();

                    return this.Ok(output.ChannelId);
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
