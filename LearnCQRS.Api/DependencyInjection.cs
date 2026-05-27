using System.Text.Json.Serialization;
using LearnCQRS.Api.Services;
using LearnCQRS.Application.Common.Interfaces;

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
        services.AddProblemDetails();
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();


        
        return services;
    }
}