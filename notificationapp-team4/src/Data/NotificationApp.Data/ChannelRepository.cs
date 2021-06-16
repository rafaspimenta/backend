using Microsoft.EntityFrameworkCore;
using NotificationApp.Domain;
using NotificationApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace NotificationApp.Data
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly AppDbContext appDbContext;

        public ChannelRepository(IUnitOfWorkProvider unitOfWorkProvider)
        {
            this.appDbContext = new AppDbContext(unitOfWorkProvider);
        }

        public void Delete(IChannel channel)
        {
            this.appDbContext.Channels.Remove((Channel)channel);
            this.appDbContext.SaveChanges();
        }

        public IEnumerable<IChannel> Get()
        {
            return this.appDbContext.Channels
                .Include(f => f.Notifications)
                .ToList();
        }

        public IChannel Get(int id)
        {
            return this.appDbContext.Channels
                .Include(f => f.Notifications)
                .FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<IChannel> Get(IEnumerable<int> ids)
        {
            return this.appDbContext.Channels
                .AsQueryable()
                .Where(f => ids.Contains(f.Id))
                .ToList();
        }

        public void Save(IChannel channel)
        {
            if (channel.Id == 0)
            {
                this.appDbContext.Channels.Add((Channel)channel);
            }
            else
            {
                this.appDbContext.Channels.Update((Channel)channel);
            }

            this.appDbContext.SaveChanges();
        }
    }
}
