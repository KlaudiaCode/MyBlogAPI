using System;
using System.Collections.Generic;
using System.Linq;
using MyBlogAPI.Models;

namespace MyBlogAPI.Data 
{
    public class SqlBlogRepo : IBlogRepo
    {
        private readonly PostContext _context;

        public SqlBlogRepo(PostContext context)
        {
            _context = context;
        }

        public void CreatePost(Post pst)
        {
            if(pst == null)
            {
                throw new ArgumentNullException(nameof(pst));
            }

            pst.Date = DateTime.Now;
            pst.UpdateDate = DateTime.Now;

            if(pst.TopicId != 0)
            {
                var check = _context.Posts.Where( p => p.PostId == pst.TopicId);

                if ( check.Count() == 0)
                {
                    throw new ArgumentNullException(nameof(pst));
                }
                else 
                {
                    _context.Posts.Add(pst);
                }
            }
            else 
            {
                _context.Posts.Add(pst);
            }
            
        }

        public void DeletePost(Post pst)
        {
            if(pst == null)
            {
                throw new ArgumentNullException(nameof(pst));
            }

            var posts = _context.Posts.Where( p => p.TopicId == pst.PostId);

            foreach (var post in posts)
            {
                _context.Posts.Remove(post);
            }

            _context.Posts.Remove(pst);
        }

        public IEnumerable<Post> GetAllTopics()
        {
            return _context.Posts.Where( p => p.TopicId == 0).ToList();
        }

        public Post GetPostById(int id)
        {
            return _context.Posts.FirstOrDefault( p => p.PostId == id);
        }
//trying
        public IEnumerable<Post> GetPostByTopic(int id)
        {
            return _context.Posts.Where( p => p.TopicId == id).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0 );
        }

        public void UpdatePost(Post pst)
        {
           pst.UpdateDate = DateTime.Now;
        }
    }
}