using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace NotificationApp.Api.SearchNotifications
{
    [Route("api/channel")]
    [ApiController]
    public class SearchNotificationsController : ControllerBase
    {
        private readonly IUnitOfWorkProvider unitOfWorkProvider;
        private readonly Application.Queries.SearchNotifications.ISearchNotificationsQuery query;

        public SearchNotificationsController(
            IUnitOfWorkProvider unitOfWorkProvider,
            Application.Queries.SearchNotifications.ISearchNotificationsQuery query)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
            this.query = query;
        }

        [HttpGet("notifications")]
        public ActionResult<IEnumerable<Application.Queries.SearchNotifications.ISearchNotificationsItem>> Get(
            [FromQuery] int? channelId)
        {
            using (this.unitOfWorkProvider.Create())
            {
                var items = this.query.Execute(
                    new SearchNotificationsInput
                    {
                        ChannelId = channelId
                    });

                return items.ToArray();
            }
        }
    }
}
