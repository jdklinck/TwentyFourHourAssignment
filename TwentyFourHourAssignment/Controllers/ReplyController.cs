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
    public class ReplyController : ApiController
    {
      

            private ReplyService CreateReplyService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var postService = new ReplyService(userId);
                return postService;
            }

            public IHttpActionResult Get()
            {
                var replyService = CreateReplyService();
                var post = replyService.GetPost();
                return Ok(post);
            }

            public IHttpActionResult GetById(int id)
            {
                var postService = CreateReplyService();
                var post = postService.GetPostById(id);
                return Ok(post);
            }
            public IHttpActionResult Reply(PostCreate replyCreate)
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
}