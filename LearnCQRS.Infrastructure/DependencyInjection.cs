using System.Security.Claims;
using System.Text;
using LeanrCQRS.Domain.Common.Interfaces;
using LearnCQRS.Application.Common.Interfaces;
using LearnCQRS.Application.Features.Students.Repositories;
using LearnCQRS.Infrastructure.Authentication.TokenGenerator;
using LearnCQRS.Infrastructure.Common.Persistence;
using LearnCQRS.Infrastructure.Students.Persistence;
using LearnCQRS.Infrastructure.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PasswordHasher = LearnCQRS.Infrastructure.Authentication.PasswordHasher.PasswordHasher;


namespace LearnCQRS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Database")));
        
        services.AddScoped<IUnitOfWork>(servicesProvider => servicesProvider.GetRequiredService<AppDbContext>());
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();

        return services;
    }
    
    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.Section, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();

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
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                RoleClaimType = ClaimTypes.Role
            });


        return services;
    }

}