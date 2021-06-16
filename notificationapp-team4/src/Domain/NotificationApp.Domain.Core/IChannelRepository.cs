using NotificationApp.Domain.Models;
using System.Collections.Generic;

namespace NotificationApp.Domain
{
    public interface IChannelRepository
    {
        IChannel Get(int id);

        IEnumerable<IChannel> Get();

        IEnumerable<IChannel> Get(IEnumerable<int> ids);

        void Save(IChannel channel);

        void Delete(IChannel channel);
    }
}
