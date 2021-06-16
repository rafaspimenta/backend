using System.Collections.Generic;

namespace NotificationApp.Domain.Models
{
    public class Channel : IChannel
    {
        private ICollection<Notification> notifications;
        private ICollection<INotification> noficationsProxy;

        public Channel()
        {
            this.notifications = new List<Notification>();
            this.noficationsProxy = new Collections.CollectionProxy<Notification, INotification>(this.notifications);
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Notification> Notifications
        {
            get => this.notifications;
            set
            {
                this.notifications = value ?? new List<Notification>();
                this.noficationsProxy = new Collections.CollectionProxy<Notification, INotification>(this.notifications);
            }
        }

        ICollection<INotification> IChannel.Notifications => this.noficationsProxy;
    }
}
