using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBlogAPI.Models
{
    public class Post
    {   [Key]
        public int PostId { get; set; }
        [Required]
        public int TopicId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public DateTime UpdateDate { get; set; }
        [Required][MaxLength(50)]
        public string Author { get; set; }
        [Required][MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

    }
}