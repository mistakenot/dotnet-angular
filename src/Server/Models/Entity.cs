using System;

namespace Server.Models
{
    public abstract class Entity : IEntity
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

    public interface IEntity
    {
        int Id { get; }

        DateTime? DeletedAt { get; }
    }

    public interface IOwnedEntity : IEntity
    {
        int AccountId { get; }
    }
}
