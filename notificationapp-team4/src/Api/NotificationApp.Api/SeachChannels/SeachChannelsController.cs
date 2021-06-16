using Microsoft.AspNetCore.Mvc;
using NotificationApp.Api.SeachChannels;
using NotificationApp.Application.Queries.SearchChannels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotificationApp.Api.SeachChannel
{
    [Route("api/channel")]
    [ApiController]
    public class SeachChannelsController
    {
        private readonly IUnitOfWorkProvider unitOfWorkProvider;
        private readonly ISearchChannelsQuery query;

        public SeachChannelsController(IUnitOfWorkProvider unitOfWorkProvider, ISearchChannelsQuery searchChannelsQuery)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
            this.query = searchChannelsQuery;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<ISearchChannelsItem>> Get([FromQuery] string channelName)
        {
            using (this.unitOfWorkProvider.Create())
            {
                var items = this.query.Execute(
                    new SearchChannelsInput
                    {
                        Name = channelName
                    });

                return items.ToArray();
            }
        }
    }
}
