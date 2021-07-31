using SharpArch.Domain.DomainModel;

namespace Domain
{
    public class UserCamp : Entity
    {
        public virtual bool IsEnabled { get; set; }

        public virtual Account Account { get; set; }
        public virtual User User { get; set; }
    }
}
