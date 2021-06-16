using Dapper;
using NotificationApp.Domain.Queries.SearchChannels;
using System.Collections.Generic;

namespace NotificationApp.Data.Queries.SearchChannels
{
    public class SearchChannelsDataQuery : ISearchChannelsDataQuery
    {
        private readonly IUnitOfWorkProvider unitOfWorkProvider;

        public SearchChannelsDataQuery(IUnitOfWorkProvider unitOfWorkProvider)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
        }

        public IEnumerable<ISearchChannelsItem> Execute(ISearchChannelsInput input)
        {
            /*var sql = $@"SELECT * from channel
                        WHERE upper(n.name) like upper(%{'input.Name'}%)";*/
            var sql = $@"SELECT * from channel
                        WHERE name = '{input.Name}'";

            return this.unitOfWorkProvider.GetConnection().Query<SearchChannelsItem>(sql);
        }
    }
}
