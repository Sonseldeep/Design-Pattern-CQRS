using LearnCQRS.Application.Common.Interfaces;
using LearnCQRS.Application.Features.Students.Repositories;
using LearnCQRS.Infrastructure.Common.Persistence;
using LearnCQRS.Infrastructure.Students.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnCQRS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Database")));
        
        services.AddScoped<IUnitOfWork>(servicesProvider => servicesProvider.GetRequiredService<AppDbContext>());
        services.AddScoped<IStudentRepository, StudentRepository>();
        return services;
    }
}