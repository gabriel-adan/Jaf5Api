using SharpArch.Domain.DomainModel;

namespace Domain
{
    public class User : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
    }
}
