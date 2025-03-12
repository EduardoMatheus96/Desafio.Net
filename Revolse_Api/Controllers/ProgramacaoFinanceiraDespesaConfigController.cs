using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resolve.Domain.Core.Bus;
using Resolve.Domain.Core.Notification;
using Resolve.Domain.Registrations.Commands.ProgramacaoFinanceiraDespesaConfig;
using Resolve.Domain.Registrations.Repositories;
using Resolve.Infra.Core.API.Controller;

namespace Resolve.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin")]
    public class ProgramacaoFinanceiraDespesaConfigController : BaseController
    {
        private readonly IProgramacaoFinanceiraDespesaRepository _repository;

        public ProgramacaoFinanceiraDespesaConfigController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler bus,
            IProgramacaoFinanceiraDespesaRepository repository)
            : base(notifications, bus)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProgramacaoFinanceiraDespesaConfigCommand command)
        {
            try
            {
                await Bus.SendAsync(command);
                return HasErrorNotifications ? Error() : Success("Programação financeira criada com sucesso!");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex, "Erro ao criar programação financeira.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProgramacaoFinanceiraDespesaConfigCommand command)
        {
            try
            {
                await Bus.SendAsync(command);
                return HasErrorNotifications ? Error() : Success("Programação financeira atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex, "Erro ao atualizar programação financeira.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteProgramacaoFinanceiraDespesaConfigCommand { Id = id };
                await Bus.SendAsync(command);
                return HasErrorNotifications ? Error() : Success("Programação financeira excluída com sucesso!");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex, "Erro ao excluir programação financeira.");
            }
        }

        [HttpGet("progressao")]
        public async Task<IActionResult> GetProgressaoMensal([FromQuery] int ano, [FromQuery] int unidadeGestoraId)
        {
            try
            {
                var result = await _repository.CalcularProgressoMensal(ano, unidadeGestoraId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex, "Erro ao calcular a progressão mensal.");
            }
        }


    }
}
