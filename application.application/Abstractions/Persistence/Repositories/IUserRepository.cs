using application.domain.Entities.User;

namespace application.application.Abstractions.Persistence.Repositories
{
    public interface IUserRepository : IRepository<User, UserId>
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken ct = default);
    }
}
