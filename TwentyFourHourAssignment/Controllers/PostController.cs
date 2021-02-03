using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TwentyFourHour.Models;
using TwentyFourHour.Service.PostServices;

namespace TwentyFourHourAssignment.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new PostService(userId);
            return noteService;
        }

        public IHttpActionResult Get()
        {
            var postService = CreatePostService();
            var post = postService.GetPost();
            return Ok(post);
        }

        public IHttpActionResult GetById(int id)
        {
            var postService = CreatePostService();
            var post = postService.GetPostById(id);
            return Ok(post);
        }
        public IHttpActionResult Post(PostCreate postCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(postCreate))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(PostEdit post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.UpdatePost(post))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();

            if (!service.DeletePost(id))
                return InternalServerError();

            return Ok();
        }
    }
}
