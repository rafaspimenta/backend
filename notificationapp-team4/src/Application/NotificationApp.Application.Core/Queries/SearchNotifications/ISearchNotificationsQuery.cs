using System.Collections.Generic;

namespace NotificationApp.Application.Queries.SearchNotifications
{
    public interface ISearchNotificationsQuery
    {
        IEnumerable<ISearchNotificationsItem> Execute(ISearchNotificationsInput input);
    }
}
