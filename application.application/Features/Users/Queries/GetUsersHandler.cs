using application.application.Abstractions.Messaging;
using application.application.Abstractions.Persistence.Repositories;
using application.application.Features.Users.Dtos;
using Microsoft.Extensions.Logging;

namespace application.application.Features.Users.Queries
{
    public sealed class GetUsersQueryHandler
        : QueryHandler<GetUsersQuery, IReadOnlyList<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(
            IUserRepository userRepository,
            ILogger<GetUsersQueryHandler> logger)
            : base(logger)
        {
            _userRepository = userRepository;
        }

        public override async Task<IReadOnlyList<UserDto>> Handle(
            GetUsersQuery request,
            CancellationToken ct)
        {
            var users = await _userRepository.GetAllAsync(ct);

            return users
                .Select(user => new UserDto(
                    user.Id.Value,
                    user.Email?.Value?? string.Empty,
                    user.Name))
                .ToList();
        }
    }
}
