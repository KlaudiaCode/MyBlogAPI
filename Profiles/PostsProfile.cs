using AutoMapper;
using MyBlogAPI.Dtos;
using MyBlogAPI.Models;

namespace MyBlogAPI.PostProfiles
{
    public class PostsProfiles : Profile
    {
        public PostsProfiles()
        {
            // Source -> Target
            CreateMap<Post, PostReadDto>();
            CreateMap<PostCreateDto, Post>();
            CreateMap<PostUpdateDto, Post>();
            CreateMap<Post, PostUpdateDto>();
        }
    }
}