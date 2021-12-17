using System.Collections.Generic;

namespace feed.Infrastructure.Email
{
    public class EmailMessage
    {  
        public List<EmailAddress> To { get; set; }
        public List<EmailAddress> From { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}