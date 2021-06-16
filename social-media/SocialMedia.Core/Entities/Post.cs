using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
