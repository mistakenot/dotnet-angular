using System.Collections.Generic;

namespace Server.Models
{
    public class Account : Entity
    {
        public int ApplicationUserId { get; set; }

        public string Email { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public List<EmailAddress> EmailAddresses { get; set;  }

    }
}
