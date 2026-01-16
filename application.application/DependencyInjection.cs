using application.application.Behaviours;
using application.application.Features.Users.Commands.CreateUser;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace application.application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserHandler).Assembly));

            services.AddValidatorsFromAssembly(
                typeof(CreateUserValidator).Assembly);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            return services;
        }
    }
}
