using System;

namespace Server.Models
{
    public class EmailHeader : Entity
    {
        public int AccountId { get; set; }

        public string Subject { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string ContentSample { get; set; }

        public EmailContent EmailContent { get; set; }
        public Account Account{ get; set; }

    }
}
