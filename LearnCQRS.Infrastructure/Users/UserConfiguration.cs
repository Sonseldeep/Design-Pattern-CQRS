using LeanrCQRS.Domain.Users;
using LeanrCQRS.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnCQRS.Infrastructure.Users;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName).IsRequired();

        builder.Property(u => u.LastName).IsRequired();

        builder.Property(u => u.Email).IsRequired();

        builder.Property("_passwordHash")
            .HasColumnName("PasswordHash")
            .IsRequired();

        builder.Property(u => u.Roles)
            .HasConversion(
                roles => string.Join(',', roles.Select(r => r.ToString())),
                s => s.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<Role>).ToList()
            )
            .HasColumnName("Roles")
            .IsRequired();
    }
}