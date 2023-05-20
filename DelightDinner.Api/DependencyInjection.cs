using DelightDinner.Api.Common.Errors;
using DelightDinner.Api.Common.Mapping;

using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DelightDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, DelightDinnerProblemDetailsFactory>();

        return services;
    }
}