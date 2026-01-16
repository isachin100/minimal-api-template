using application.application.Abstractions.Messaging;
using application.application.Abstractions.Persistence.Repositories;
using application.application.Features.Users.Dtos;
using application.domain.Entities.User;
using Microsoft.Extensions.Logging;

namespace application.application.Features.Users.Queries
{
    public sealed class GetUserByIdHandler : QueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository, ILogger<GetUserByIdHandler> logger)
            : base(logger)
        {
            _userRepository = userRepository;
        }

        public override async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken ct)
        {
            var user = await _userRepository.GetByIdAsync(new UserId(request.Id), ct);
            if (user == null)
                throw new Exception("User not found");

            return new UserDto(user.Id.Value, user.Email?.Value??string.Empty, user.Name);
        }
    }
}
