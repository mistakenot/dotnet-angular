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

        public override bool Equals(object that)
        {
            if (that is Entity)
            {
                return this.Id == (that as Entity).Id;
            }

            return base.Equals(that);
        }
    }
}
