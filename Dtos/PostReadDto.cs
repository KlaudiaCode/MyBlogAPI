using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBlogAPI.Dtos
{
    public class PostReadDto
    {  
        public int PostId { get; set; }

        public int TopicId { get; set; }

        public DateTime Date { get; set; }
        
        public DateTime UpdateDate { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

    }
}