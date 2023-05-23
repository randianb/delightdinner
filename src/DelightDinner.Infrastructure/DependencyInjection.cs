using DelightDinner.Application.Common.Interfaces.Authentication;
using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Application.Common.Interfaces.Services;
using DelightDinner.Infrastructure.Authentication;
using DelightDinner.Infrastructure.Persistence;
using DelightDinner.Infrastructure.Persistence.Interceptors;
using DelightDinner.Infrastructure.Persistence.Repositories;
using DelightDinner.Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DelightDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services
            .AddPersistance(configuration)
            .AddAuth(configuration);  
        
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();        

        return services;
    }

    public static IServiceCollection AddPersistance(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddDbContext<DelightDinnerDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserReposetory, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IDinnerRepository, DinnerRepository>();

        services.AddScoped<PublishDomainEventsInterceptor>();

        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return services;
    }
}