

namespace Resolve.Infra.Core.API.Response
{
    public class BaseEnvelopeResponse<T>
    {
        protected internal BaseEnvelopeResponse(T result, string errorMessage = "")
        {
            Result = result;
            ErrorMessage = errorMessage;
            OcurredIn = DateTime.Now;
        }

        public T Result { get; }
        public bool isSuccess => string.IsNullOrWhiteSpace(ErrorMessage);
        public string ErrorMessage { get; }
        public DateTime OcurredIn { get; }

    }
}
