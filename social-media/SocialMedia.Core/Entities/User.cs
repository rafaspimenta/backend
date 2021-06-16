using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
