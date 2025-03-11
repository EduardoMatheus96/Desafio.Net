using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resolve.Domain.Core.Auth;
using Resolve.Domain.Core.Bus;
using Resolve.Domain.Core.Notification;
using Resolve.Infra.Core.Auth;
using Resolve.Infra.Core.Bus;
using Resolve.Infra.Data.Context;

namespace Resolve.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void AddInFrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDbContext(services, configuration);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            RegisterCommands(services);
            RegisterDomainEvents(services);
            RegisterRepositories(services);
            RegisterDomainServices(services);
        }

        private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ApplyMigrations(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }

        static void RegisterCommands(IServiceCollection services)
        {

        }

        static void RegisterRepositories(this IServiceCollection services)
        {

        }

        static void RegisterDomainEvents(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

        static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
        }
    }
}
