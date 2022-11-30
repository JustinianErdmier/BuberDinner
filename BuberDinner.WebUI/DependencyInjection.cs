using BuberDinner.WebUI.Common.Errors;
using BuberDinner.WebUI.Common.Mapping;

using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.WebUI;

public static class DependencyInjection
{
    public static IServiceCollection AddWebUI(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
        services.AddMapping();

        return services;
    }
}
