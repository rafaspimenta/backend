using NotificationApp.Application.Queries.SearchChannels;

namespace NotificationApp.Api.SeachChannels
{
    public class SearchChannelsInput : ISearchChannelsInput
    {
        public string Name { get; set; }
    }
}
