using System.Security.Claims;
using Resolve.Domain.Core.Enums;

namespace Resolve.Domain.Core.Auth
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string role);
    }
}
