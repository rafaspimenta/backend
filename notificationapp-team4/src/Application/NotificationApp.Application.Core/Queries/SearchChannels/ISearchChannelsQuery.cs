using System.Collections.Generic;

namespace NotificationApp.Application.Queries.SearchChannels
{
    public interface ISearchChannelsQuery
    {
        IEnumerable<ISearchChannelsItem> Execute(ISearchChannelsInput input);
    }
}