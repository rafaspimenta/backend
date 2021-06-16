using System;

namespace NotificationApp.Domain.Models
{
    public class Notification : INotification
    {
        public Notification()
        {
            this.Date = DateTime.Now;
        }

        public int Id { get; set; }

        public int ChannelId { get; set; }

        public Channel Channel { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public DateTime Date { get; set; }
    }
}
