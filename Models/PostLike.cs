using System.Threading;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System;

namespace feed.Models
{
    public class PostLike
    {
        [ForeignKey("Post")]
        public int PostId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }
    }
}