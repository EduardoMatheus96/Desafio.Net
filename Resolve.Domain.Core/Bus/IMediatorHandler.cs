using Resolve.Domain.Core.Command;
using Resolve.Domain.Core.Event;

namespace Resolve.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendAsync<T>(T command) where T : BaseCommand;
        Task RaiseAsync<T>(T command) where T : BaseEvent;

    }
}
