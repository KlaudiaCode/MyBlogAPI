using System.Collections.Generic;
using MyBlogAPI.Models;

namespace MyBlogAPI.Data
{
    public class MockBlogRepo : IBlogRepo
    {
        public void CreatePost(Post pst)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePost(Post pst)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Post> GetAllTopics()
        {
            var post = new List<Post>
            {
                new Post{PostId=0, TopicId=0, Author="Kladia"},
                new Post{PostId=1, TopicId=2, Author="Klauda"},
                new Post{PostId=2, TopicId=0, Author="Kldia"}
            };
            return post;
        }

        public Post GetPostById(int id)
        {
            return new Post{PostId=0, TopicId=0, Author="Klaudia"};
        }

        public IEnumerable<Post> GetPostByTopic(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePost(Post pst)
        {
            throw new System.NotImplementedException();
        }
    }
}