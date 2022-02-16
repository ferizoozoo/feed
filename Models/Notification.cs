using System.Text;
using System;

namespace feed.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int ReceiverId { get; set; }
        public bool Seen { get; set; }
        public DateTime SeenAt { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}