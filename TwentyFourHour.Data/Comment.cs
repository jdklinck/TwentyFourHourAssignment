using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Data
{
   public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Text { get; set; }
        public Guid UserId { get; set; }

        public virtual List<Reply> Replies { get; set; }


        [ForeignKey(nameof (Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
