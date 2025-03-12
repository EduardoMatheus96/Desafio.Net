using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Resolve.Domain.Core.Auth;
using Resolve.Domain.Core.Enums;

namespace Resolve.Infra.Core.Auth
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        private readonly string _jwtKey;
        private readonly string _jwtIssuer;
        private readonly string _jwtAudience;

        public JwtService(IConfiguration config)
        {
            _config = config;

            _jwtKey = _config["JWT:Key"] ?? throw new ArgumentNullException("JWT:Key não pode ser nulo.");
            _jwtIssuer = _config["JWT:Issuer"] ?? throw new ArgumentNullException("JWT:Issuer não pode ser nulo.");
            _jwtAudience = _config["JWT:Audience"] ?? throw new ArgumentNullException("JWT:Audience não pode ser nulo.");
        }

        public string GenerateToken(string userId, string role)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", userId),
                new Claim("Type", role.ToString()),
            };

            return JwtToken(claims);
        }


        private string JwtToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
