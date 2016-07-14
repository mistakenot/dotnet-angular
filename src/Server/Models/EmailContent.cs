using System;
using Newtonsoft.Json;

namespace Server.Models
{
    public class EmailContent : Entity
    {
        public int EmailHeaderId { get; set; }

        public string Content { get; set; }

        [JsonIgnore]
        public EmailHeader EmailHeader { get; set; }
    }
}
