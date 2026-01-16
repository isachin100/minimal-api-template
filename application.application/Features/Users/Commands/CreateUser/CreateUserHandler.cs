using application.application.Abstractions.Messaging;
using application.application.Abstractions.Persistence;
using application.application.Abstractions.Persistence.Repositories;
using application.domain.Entities.User;

namespace application.application.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserHandler : ICommandHandler<CreateUserCommand, UserId>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(
            IUserRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserId> Handle(
            CreateUserCommand command,
            CancellationToken ct)
        {
            var user = User.Create(Email.Create(command.Email),command.Name);

            await _repository.AddAsync(user, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return user.Id;
        }
    }

}
