using DelightDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace DelightDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
