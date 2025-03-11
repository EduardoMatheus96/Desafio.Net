using MediatR;

namespace Resolve.Domain.Core.Event
{
    public abstract class BaseEvent : INotification
    {
        public DateTime TimesTamp {  get; private set; }
        protected BaseEvent()
            => TimesTamp = DateTime.Now;
    }
}
