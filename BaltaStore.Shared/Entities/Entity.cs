using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get;private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
