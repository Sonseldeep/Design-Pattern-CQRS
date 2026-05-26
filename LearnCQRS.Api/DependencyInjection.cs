using System.Text.Json.Serialization;

namespace LearnCQRS.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServiceCollection(this IServiceCollection services)
    {
        // Controllers with JSON enum converter
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        
        return services;
    }
}