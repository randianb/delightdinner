using DelightDinner.Application.Common.Interfaces.Authentication;
using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Application.Common.Services;
using DelightDinner.Infrastructure.Authentication;
using DelightDinner.Infrastructure.Persistence;
using DelightDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DelightDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserReposetory, UserRepository>();

        return services;
    }
}
