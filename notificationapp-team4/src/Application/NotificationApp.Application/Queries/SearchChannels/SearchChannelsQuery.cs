using System.Collections.Generic;
using System.Linq;

namespace NotificationApp.Application.Queries.SearchChannels
{
    public class SearchChannelsQuery : ISearchChannelsQuery
    {
        private readonly Domain.Queries.SearchChannels.ISearchChannelsDataQuery dataQuery;

        public SearchChannelsQuery(Domain.Queries.SearchChannels.ISearchChannelsDataQuery dataQuery)
        {
            this.dataQuery = dataQuery;
        }

        public IEnumerable<ISearchChannelsItem> Execute(ISearchChannelsInput input)
        {
            var result = this.dataQuery.Execute(new Input
            {
                Name = input.Name,
            });

            return result.Select(f => new SearchChannelsItem(f));
        }

        private class Input : Domain.Queries.SearchChannels.ISearchChannelsInput
        {
            public string Name { get; set;  }
        }
    }
}
