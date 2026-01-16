using application.application.Abstractions.Persistence.Repositories;
using application.domain.Entities.User;
using application.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace application.Infrastructure.Repositories
{
    public sealed class UserRepository
       : Repository<User, UserId>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        // User-specific method
        public async Task<User?> GetByEmailAsync(string email, CancellationToken ct = default)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email.Value == email, ct);
        }
    }
}
