using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Service
{
    class ReplyServices 
    {
        
            private readonly Guid _userId;
            public ReplyService(Guid userId)
            {
                _userId = userId;
            }

            public bool CreateReply(ReplyCreate model)
            {
                var entity =
                    new Reply()
                    {
                        Author = _userId,
                        Title = model.Title,
                        Text = model.Text,
                        CreatedUtc = DateTimeOffset.Now
                    };
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Post.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }

            public IEnumerable<PostReplyItem> GetReply()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                        .Reply
                        .Where(e => e.Author == _userId)
                        .Select(
                            e =>
                            new ReplyListItem
                            {
                                Title = e.Title,
                            //Text = entity.Text,
                            //CreatedUtc = entity.CreatedUtc,
                            //ModifiedUtc = DateTimeOffset.UtcNow
                        }
                            );
                    return query.ToArray();
                }
            }

            public ReplyDetail GetReplyById(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Reply
                        .Single(e => e.Id == id && e.Author == _userId);
                    return
                        new ReplyDetail
                        {
                            Id = entity.Id,
                            Title = entity.Title,
                            Text = entity.Text,
                            CreatedUtc = entity.CreatedUtc,
                            ModifiedUtc = DateTimeOffset.UtcNow
                        };
                }
            }
            public bool UpdateReply(PostEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Reply
                        .Single(e => e.Id == model.Id && e.Author == _userId);
                    entity.Title = model.Title;
                    entity.Text = model.Text;
                    entity.ModifiedUtc = DateTimeOffset.UtcNow;

                    return ctx.SaveChanges() == 1;
                }
            }

            public bool DeletePost(int Id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Reply
                        .Single(e => e.Id == Id && e.Author == _userId);
                    ctx.Reply.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
        
    }
}
