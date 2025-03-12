using Resolve.Domain.Core.Command;

namespace Resolve.Domain.Registrations.Commands.Auth
{
    public class LoginCommand : BaseCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
