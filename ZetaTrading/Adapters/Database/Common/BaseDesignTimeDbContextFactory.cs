using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ZetaTrading.Adapters.Database.Common;

public abstract class BaseDesignTimeDbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>
    where TContext : DbContext
{
    public TContext CreateDbContext(string[] args)
    {
        return CreateDbContext(
            new DbContextOptionsBuilder<TContext>()
                .UseNpgsql("Server=localhost;Port=5432;")
                .Options);
    }

    protected abstract TContext CreateDbContext(DbContextOptions<TContext> options);
}
