using System.Text.Json.Serialization;
using MediatR;

namespace Resolve.Domain.Core.Command
{
    public abstract class BaseCommand : INotification
    {
        protected BaseCommand()
        {
            TimesTamp = DateTime.Now;
            MessageType = GetType().Name;
        }

        [JsonIgnore]
        public string MessageType { get; set; }
        [JsonIgnore]
        public DateTime TimesTamp { get; set; }
    }
}
