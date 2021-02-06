using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;
using TwentyFourHour.Models;
using TwentyFourHour.Service.ReplyServices;

namespace TwentyFourHourAssignment.Controllers
{
    [Authorize]
    public class ReplyController : ApiController
    {
      

            private ReplyService CreateReplyService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var replyService = new ReplyService(userId);
                return replyService;
            }

            public IHttpActionResult Get()
            {
                var replyService = CreateReplyService();
                var reply = replyService.GetReply();
                return Ok(reply);
            }

            public IHttpActionResult GetById(int id)
            {
                var replyService = CreateReplyService();
                var reply = replyService.GetReplyById(id);
                return Ok(reply);
            }
            public IHttpActionResult Reply(ReplyCreate replyCreate)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateReplyService();

                if (!service.CreateReply(replyCreate))
                    return InternalServerError();

                return Ok();
            }
            public IHttpActionResult Put(ReplyEdit reply)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateReplyService();

                if (!service.UpdateReply(reply))
                    return InternalServerError();

                return Ok();
            }
            public IHttpActionResult Delete(int id)
            {
                var service = CreateReplyService();

                if (!service.DeleteReply(id))
                    return InternalServerError();

                return Ok();
            }
        
    }
}
