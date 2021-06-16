using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }

        public async Task<Post> CreatePost(Post post)
        {

            /*var user = new User() { Name = "Rafael" };
            var posts = Enumerable.Range(0, 3).Select(x =>
                new Post()
                {
                    Description = $"Description {x}",
                    Date = DateTime.UtcNow,
                    Image = $"https://misapis.com/{x}",
                    UserId = x * 2,
                    Users = new List<User>() { user }
                });

            var newPosts = new List<Post>();
            foreach (var item in posts)
            {
                var newPost = await _context.Posts.AddAsync(item);
                newPosts.Add(newPost.Entity);
            }*/
            var newPost = await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return newPost.Entity;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.Include(u => u.Users).ToListAsync();
            return posts;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return post;
        }
    }
}
