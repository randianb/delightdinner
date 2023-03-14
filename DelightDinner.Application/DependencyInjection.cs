using DelightDinner.Application.Services.Authentication.Commands;
using DelightDinner.Application.Services.Authentication.Query;
using Microsoft.Extensions.DependencyInjection;

namespace DelightDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

        return services;
    }
}
