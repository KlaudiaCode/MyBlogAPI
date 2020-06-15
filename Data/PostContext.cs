using Microsoft.EntityFrameworkCore;
using MyBlogAPI.Models;

namespace MyBlogAPI.Data
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> opt) : base(opt)
        {
            
        }

        public DbSet<Post> Posts { get; set; } 
    }
}