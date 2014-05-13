using System;

namespace SportsStore.Domain
{
    public abstract class Entity
    {
        public Entity()
        {
            this.Created = DateTime.Now;
            this.Modified = DateTime.Now;
        }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}