using System.Collections.Generic;

namespace NotificationApp.Domain.Queries.SearchNotifications
{
    public interface ISearchNotificationsDataQuery
    {
        IEnumerable<ISearchNotificationsItem> Execute(ISearchNotificationsInput input);
    }
}
