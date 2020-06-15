using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyBlogAPI.Data;
using MyBlogAPI.Dtos;
using MyBlogAPI.Models;

namespace MyBlogAPI.Controllers
{   

    //api/posts
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IBlogRepo _repository;
        private readonly IMapper _mapper;

        public PostsController(IBlogRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // GET api/posts
        [HttpGet]
        public ActionResult <IEnumerable<PostReadDto>> GetAllTopics()
        {
            var postItems = _repository.GetAllTopics();
            return Ok(_mapper.Map<IEnumerable<PostReadDto>>(postItems));
        }

        // GET api/posts/{id}
        [HttpGet("{id}" , Name="GetPostById")]
        public ActionResult <PostReadDto> GetPostById(int id)
        {
            var postItem = _repository.GetPostById(id);
            if(postItem != null)
            {
                return Ok(_mapper.Map<PostReadDto>(postItem));
            }
            return NotFound();
        }

        // GET api/posts/{id}/all
        [HttpGet("{id}/all" , Name="GetPostByTopic")] 
        public ActionResult <PostReadDto> GetPostByTopic(int id)
        {
            var postItem = _repository.GetPostByTopic(id);
            if(postItem != null)
            {
                return Ok(_mapper.Map<IEnumerable<PostReadDto>>(postItem));
            }
            return NotFound();
        }


        // POST api/posts
        [HttpPost]
        public ActionResult <PostReadDto> CreatePost(PostCreateDto postCreateDto)
        {
            var postModel = _mapper.Map<Post>(postCreateDto);
            _repository.CreatePost(postModel);
            _repository.SaveChanges();

            var postReadDto = _mapper.Map<PostReadDto>(postModel);

            return CreatedAtRoute(nameof(GetPostById), new {Id = postReadDto.PostId}, postReadDto);
            //return created
        }

        // PUT api/posts/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePost(int id, PostUpdateDto postUpdateDto)
        {
            var postModelFromRepo = _repository.GetPostById(id);
            if(postModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(postUpdateDto, postModelFromRepo);
            // for now - UpdatePost doing nothing, but it is nice to implement it for future, if something will change
            _repository.UpdatePost(postModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

         // PATCH api/posts/{id}
         [HttpPatch("{id}")]
         public ActionResult PartialPostUpdate(int id, JsonPatchDocument<PostUpdateDto> patchDoc)
        {
            var postModelFromRepo = _repository.GetPostById(id);
            if(postModelFromRepo == null)
            {
                return NotFound();
            }

            var postToPatch = _mapper.Map<PostUpdateDto>(postModelFromRepo);
            patchDoc.ApplyTo(postToPatch, ModelState);

            if(!TryValidateModel(postToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(postToPatch, postModelFromRepo);

            _repository.UpdatePost(postModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/posts/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePost(int id)
        {
            var postModelFromRepo = _repository.GetPostById(id);
            if(postModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeletePost(postModelFromRepo);        
            _repository.SaveChanges();

            return NoContent();
        }
    }
}