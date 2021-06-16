using Dapper;
using NotificationApp.Domain.Queries.SearchNotifications;
using System.Collections.Generic;

namespace NotificationApp.Data.Queries.SearchNotifications
{
    public class SearchNotificationsDataQuery : ISearchNotificationsDataQuery
    {
        private readonly IUnitOfWorkProvider unitOfWorkProvider;

        public SearchNotificationsDataQuery(IUnitOfWorkProvider unitOfWorkProvider)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
        }

        public IEnumerable<ISearchNotificationsItem> Execute(ISearchNotificationsInput input)
        {
            var sql = "SELECT " +
                "n.ChannelId AS ChannelId, n.Id AS NotificationId, c.Name AS ChannelName, n.Title, n.Url, n.Date " +
                "FROM notification n " +
                "INNER JOIN channel c ON n.ChannelId = c.Id";

            if (input.ChannelId.HasValue)
            {
                sql += $" WHERE n.ChannelId='{input.ChannelId}'";
            }

            return this.unitOfWorkProvider.GetConnection().Query<SearchNotificationsItem>(sql);
        }
    }
}
