using MediatR;
using Resolve.Domain.Core.Bus;
using Resolve.Domain.Core.Notification;
using Resolve.Domain.Registrations.Commands.Auth;
using Resolve.Domain.Registrations.Repositories;
using Resolve.Domain.Core.Enums;
using Resolve.Domain.Core.Auth;
using Resolve.Domain.Core.Command;

namespace Resolve.Domain.Registrations.CommandHandlers.Auth
{
    public class LoginCommandHandler : BaseCommandHandler, INotificationHandler<LoginCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(IMediatorHandler bus, IUserRepository userRepository, IJwtService jwtService)
            : base(bus)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task Handle(LoginCommand notification, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(notification.Username) || string.IsNullOrEmpty(notification.Password))
            {
                NotifyDomainValidation(DomainNotificationType.Error, "Usuário e senha são obrigatórios.");
                return;
            }

            var user = await _userRepository.ValidateUserAsync(notification.Username, notification.Password);

            if (user == null)
            {
                NotifyDomainValidation(DomainNotificationType.Error, "Usuário ou senha inválidos.");
                return;
            }

            var token = _jwtService.GenerateToken(user.Id.ToString(), user.Role);
            await Bus.RaiseAsync(DomainNotification.Create(DomainNotificationType.Success, token));
        }
    }
}
