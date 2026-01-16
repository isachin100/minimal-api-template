using application.domain.Common;
using application.domain.Entities.User.Events;

namespace application.domain.Entities.User
{
    public class User : AggregateRoot<UserId>
    {
        private User() { } // EF Core

        public new UserId Id { get; private set; } = UserId.New();

        public required string Name { get; set; }

        public Email? Email { get; private set; }

        public void ChangeEmail(Email email)
        {
            Email = email;
        }

        public static User Create(Email email, string name)
        {
            var user = new User
            {
                Id = UserId.New(),
                Name = name,
                Email = email
            };

            user.AddDomainEvent(new UserCreatedDomainEvent(user));
            return user;
        }

    }
}
