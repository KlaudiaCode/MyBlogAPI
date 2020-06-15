using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlogAPI.Dtos
{
    public class PostCreateDto
    {   
        public int TopicId { get; set; }

        [Required][MaxLength(50)]
        public string Author { get; set; }

        [Required][MaxLength(50)]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }

    }
}