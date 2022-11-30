using System.Reflection;

using Mapster;

using MapsterMapper;

namespace BuberDinner.WebUI.Common.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        TypeAdapterConfig mappingConfig = TypeAdapterConfig.GlobalSettings;
        mappingConfig.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(mappingConfig);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
