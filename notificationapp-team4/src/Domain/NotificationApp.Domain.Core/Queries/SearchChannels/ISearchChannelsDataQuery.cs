using System.Collections.Generic;

namespace NotificationApp.Domain.Queries.SearchChannels
{
    public interface ISearchChannelsDataQuery
    {
        IEnumerable<ISearchChannelsItem> Execute(ISearchChannelsInput input);
    }
}