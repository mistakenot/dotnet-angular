using System;

namespace Server.Models
{
    public class EmailAddress : Entity, IOwnedEntity
    {
        public int AccountId { get; set; }

        public string Address { get; set; }

        public Account Account { get; set; }
    }
}
