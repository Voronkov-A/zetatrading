using Microsoft.EntityFrameworkCore;
using ZetaTrading.Adapters.Database.Common;

namespace ZetaTrading.Adapters.Database.Journal;

public class JournalDesignTimeDbContextFactory : BaseDesignTimeDbContextFactory<JournalContext>
{
    protected override JournalContext CreateDbContext(DbContextOptions<JournalContext> options)
    {
        return new JournalContext(options);
    }
}
