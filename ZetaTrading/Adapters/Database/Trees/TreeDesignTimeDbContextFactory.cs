using Microsoft.EntityFrameworkCore;
using ZetaTrading.Adapters.Database.Common;

namespace ZetaTrading.Adapters.Database.Trees;

public class TreeDesignTimeDbContextFactory : BaseDesignTimeDbContextFactory<TreeContext>
{
    protected override TreeContext CreateDbContext(DbContextOptions<TreeContext> options)
    {
        return new TreeContext(options);
    }
}
