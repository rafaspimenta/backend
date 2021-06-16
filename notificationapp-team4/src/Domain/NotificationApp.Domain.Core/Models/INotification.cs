using System;

namespace NotificationApp.Domain.Models
{
    public interface INotification
    {
        int Id { get; }

        int ChannelId { get; set; }

        string Title { get; set; }

        string Url { get; set; }

        DateTime Date { get; set; }
    }
}
