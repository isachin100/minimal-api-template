using application.application.Abstractions.Messaging;
using application.domain.Entities.User;

namespace application.application.Features.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand(string Email, string Name): ICommand<UserId>;
}
