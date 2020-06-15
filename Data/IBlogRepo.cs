using System.Collections.Generic;
using MyBlogAPI.Models;

namespace MyBlogAPI.Data
{
    public interface IBlogRepo
    {
        bool SaveChanges();

        IEnumerable<Post> GetAllTopics();
        Post GetPostById(int id);
        IEnumerable<Post> GetPostByTopic(int id);
        void CreatePost(Post pst);
        void UpdatePost(Post pst);
        void DeletePost(Post pst);
    }
}