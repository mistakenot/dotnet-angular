using System;

namespace Server.Models
{
    public class EmailContent : Entity
    {
        public int EmailHeaderId { get; set; }

        public string Content { get; set; }

        public EmailHeader EmailHeader { get; set; }
    }
}
