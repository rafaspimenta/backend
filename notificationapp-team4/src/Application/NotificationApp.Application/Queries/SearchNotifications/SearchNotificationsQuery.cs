using System.Collections.Generic;
using System.Linq;

namespace NotificationApp.Application.Queries.SearchNotifications
{
    public class SearchNotificationsQuery : ISearchNotificationsQuery
    {
        private readonly Domain.Queries.SearchNotifications.ISearchNotificationsDataQuery dataQuery;

        public SearchNotificationsQuery(
            Domain.Queries.SearchNotifications.ISearchNotificationsDataQuery dataQuery)
        {
            this.dataQuery = dataQuery;
        }

        public IEnumerable<ISearchNotificationsItem> Execute(ISearchNotificationsInput input)
        {
            var items = this.dataQuery.Execute(new Input(input));

            return items.Select(f => new SearchNotiicationsItem(f));
        }

        private class Input : Domain.Queries.SearchNotifications.ISearchNotificationsInput
        {
            private readonly ISearchNotificationsInput input;

            public Input(ISearchNotificationsInput input)
            {
                this.input = input;
            }

            public int? ChannelId => this.input.ChannelId;
        }
    }
}
