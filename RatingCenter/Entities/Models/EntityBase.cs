using System;

namespace Entities.Models
{
    public abstract class EntityBase
    {
        private DateTime? _createdOn;

        public DateTime? CreatedOn
        {
            get => _createdOn ?? DateTime.UtcNow;
            internal set => _createdOn = value;
        }
    }
}
