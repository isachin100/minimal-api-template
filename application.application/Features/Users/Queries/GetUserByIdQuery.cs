using application.application.Abstractions.Messaging;
using application.application.Features.Users.Dtos;

namespace application.application.Features.Users.Queries
{
    public sealed record GetUserByIdQuery(Guid Id) : IQuery<UserDto>;
}
