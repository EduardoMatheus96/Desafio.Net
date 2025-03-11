using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Resolve.Domain.Core.Bus;
using Resolve.Domain.Core.Notification;
using MediatR;
using Resolve.Infra.Core.API.Response;
using System.Net;
using Resolve.Domain.Core.Enums;



namespace Resolve.Infra.Core.API.Controller
{
    public class BaseController : ControllerBase, IDisposable
    {
        protected readonly IMediatorHandler bus;
        readonly DomainNotificationHandler _notifications;
        readonly TelemetryClient _telemetry = new TelemetryClient();

        public BaseController(INotificationHandler<DomainNotification> notifications, IMediatorHandler bus)
        {
            this.bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected bool HasErrorNotifications { get { return _notifications.HasErrorNotifications(); } }

        protected IEnumerable<DomainNotification> SucessNotifications { get { return _notifications.GetNotifications().Where(x => x.Key == DomainNotificationType.Success); } }

        protected IActionResult Error(string errorMessage)
            => BadRequest(EnvelopeResponse.Error(errorMessage));

        protected IActionResult InternalServerError(Exception exception)
        {
            _telemetry.TrackException(exception);
            return StatusCode((int)HttpStatusCode.InternalServerError, EnvelopeResponse.Error(exception.Message));
        }

        protected IActionResult InternalServerError(Exception exception, string errorMessage)
        {
            _telemetry.TrackException(exception);
            return StatusCode((int)HttpStatusCode.InternalServerError, EnvelopeResponse.Error(exception.Message));
        }

        protected IActionResult Error()
        {
            var notificationValues = _notifications.GetNotifications().Where(x => x.Key == DomainNotificationType.Error).Select(n => n.Value);
            return BadRequest(EnvelopeResponse.Error(string.Join(", ", notificationValues)));
        }

        protected IActionResult Error(HttpStatusCode statusCode, string errorMessage)
            => StatusCode((int)statusCode, EnvelopeResponse.Error(errorMessage));

        protected IActionResult Success<T>(T value) where T : class
            => Ok(EnvelopeResponse.Success(value));

        protected IActionResult Success<T>(HttpStatusCode statusCode, T value) where T : class
            => StatusCode((int)statusCode, EnvelopeResponse.Success(value));

        protected IActionResult Success()
            => Ok(EnvelopeResponse.Success());

        public void Dispose()
        {
            _notifications.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
