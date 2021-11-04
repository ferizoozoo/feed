using System;

namespace feed.Models
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LikedByUser { get; set; }
        public int LikeCount { get; set; }
    }
}