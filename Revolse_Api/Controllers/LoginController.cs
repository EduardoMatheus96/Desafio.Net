using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resolve.Domain.Core.Auth;
using Resolve.Domain.Registrations.Repositories;
using Resolve.Domain.Registrations.ViewModels.Auth;

namespace Resolve.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserRepository _userRepository;

        public LoginController(IJwtService jwtService, IUserRepository userRepository)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Usuário e senha são obrigatórios.");

            var user = await _userRepository.ValidateUserAsync(request.Username, request.Password);

            if (user == null)
                return Unauthorized("Usuário ou senha inválidos.");

            var token = _jwtService.GenerateToken(user.Id.ToString(), user.Role);
            return Ok(new { Token = token });
        }
    }
}
