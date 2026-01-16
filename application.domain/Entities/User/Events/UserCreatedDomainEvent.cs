using application.domain.Common.Interfaces;

namespace application.domain.Entities.User.Events
{
    public class UserCreatedDomainEvent : IDomainEvent
    {
        private readonly User createdUser;
        public UserCreatedDomainEvent(User createdUser)
        {
            this.createdUser = createdUser;
        }
    }
}
