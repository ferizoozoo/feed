using System;
using System.Collections.Generic;

namespace feed.Models
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsLikedByUser { get; set; }

        public ICollection<PostLike> Likes { get; set; }
    }
}