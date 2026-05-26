using LeanrCQRS.Domain.Students;
using LearnCQRS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LearnCQRS.Infrastructure.Common.Persistence;

public class AppDbContext : DbContext, IUnitOfWork
{
    public DbSet<Student> Students { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    

    public async Task CommitChangesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);
    }
}

