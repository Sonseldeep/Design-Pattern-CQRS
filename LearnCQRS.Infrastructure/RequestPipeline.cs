using LearnCQRS.Infrastructure.Common.Persistence.Middleware;
using Microsoft.AspNetCore.Builder;

namespace LearnCQRS.Infrastructure;


public static class RequestPipeline
{
    public static IApplicationBuilder AddInfrastructureMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<EventualConsistencyMiddleware>();

        return builder;
    }
}