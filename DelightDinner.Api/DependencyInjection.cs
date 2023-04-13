using Microsoft.AspNetCore.Mvc.Infrastructure;

using DelightDinner.Api.Common.Errors;
using DelightDinner.Api.Common.Mapping;

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
