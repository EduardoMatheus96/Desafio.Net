using MediatR;
using Resolve.Domain.Core.Bus;
using Resolve.Domain.Core.Command;
using Resolve.Domain.Registrations.Commands.ProgramacaoFinanceiraDespesaConfig;
using Resolve.Domain.Registrations.Entities;
using Resolve.Domain.Registrations.Repositories;

namespace Resolve.Domain.Registrations.CommandHandlers
{
    public class ProgramacaoFinanceiraDespesaConfigCommandHandler : BaseCommandHandler,
        INotificationHandler<CreateProgramacaoFinanceiraDespesaConfigCommand>,
        INotificationHandler<UpdateProgramacaoFinanceiraDespesaConfigCommand>,
        INotificationHandler<DeleteProgramacaoFinanceiraDespesaConfigCommand>
    {
        private readonly IProgramacaoFinanceiraDespesaRepository _repository;

        public ProgramacaoFinanceiraDespesaConfigCommandHandler(
            IMediatorHandler bus,
            IProgramacaoFinanceiraDespesaRepository repository)
            : base(bus)
        {
            _repository = repository;
        }

        public Task Handle(CreateProgramacaoFinanceiraDespesaConfigCommand notification, CancellationToken cancellationToken)
        {
            if (NotifyErrorDomainValidation(_repository.GetById(notification.ProgramacaoFinanceiraDespesaConfigId) != null, "This Finance Program is already registered"))
                return Task.CompletedTask;

            var programacaoFinanceira = ProgramacaoFinanceiraDespesaConfig.Create(notification);
            _repository.AddOrUpdate(programacaoFinanceira);
            return Task.CompletedTask;
        }

        public async Task Handle(UpdateProgramacaoFinanceiraDespesaConfigCommand notification, CancellationToken cancellationToken)
        {
            var programacao = _repository.GetById(notification.Id);

            if (NotifyErrorDomainValidation(programacao == null, "Programação financeira não encontrada."))
                return;

            programacao.Update(notification);
            _repository.AddOrUpdate(programacao);

            return;
        }

        public async Task Handle(DeleteProgramacaoFinanceiraDespesaConfigCommand notification, CancellationToken cancellationToken)
        {
            var programacao = _repository.GetById(notification.Id);

            if (NotifyErrorDomainValidation(programacao == null, "Programação financeira não encontrada."))
                return;

            await _repository.DeleteAsync(notification.Id);

            return;
        }
    }
}
