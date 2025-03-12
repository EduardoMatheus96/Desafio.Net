using Resolve.Domain.Registrations.Entities;

namespace Resolve.Domain.Registrations.Repositories
{
    public interface IUserRepository
    {
        Task<User?> ValidateUserAsync(string username, string password);
    }
}
