using System.Collections.Generic;

namespace NotificationApp.Domain.Models
{
    public interface IChannel
    {
        int Id { get; }

        string Name { get; set; }

        ICollection<INotification> Notifications { get; }
    }
}
