using System;

namespace Server.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Entity()
        {
            DeletedAt = null;
        }
    }
}
