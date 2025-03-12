
using Microsoft.EntityFrameworkCore;
using Resolve.Domain.Registrations.Entities;
using Resolve.Domain.Registrations.Repositories;
using Resolve.Infra.Data.Context;

namespace Resolve.Infra.Data.Repositories.SqlServer
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly List<User> _mockedUsers = new List<User>
        {
            new User("admin", "123", "Admin") { Id = 1 }
        };

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> ValidateUserAsync(string username, string password)
        {
            return await Task.FromResult(_mockedUsers.FirstOrDefault(u => u.Username == username && u.Password == password));
        }
    }
}
