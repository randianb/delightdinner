using DelightDinner.Application.Authentication.Commands.Register;
using DelightDinner.Application.Authentication.Common;
using DelightDinner.Application.Common.Behaviors;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DelightDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services.AddScoped<
            IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>, 
            ValidationRegisterCommandBehavior>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
