using Microsoft.EntityFrameworkCore;
using ZetaTrading.Adapters.Database.Common.Converters;
using ZetaTrading.Adapters.Database.Trees.Configurations;
using ZetaTrading.Domain.Common;
using ZetaTrading.Domain.TreeNodes;

namespace ZetaTrading.Adapters.Database.Trees;

public class TreeContext : DbContext
{
    public const string SchemaName = "trees";

    public TreeContext(DbContextOptions<TreeContext> options) : base(options)
    {
    }

    public DbSet<TreeNode> TreeNodes { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaName);
        modelBuilder.ApplyConfiguration(new TreeNodeConfiguration());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<DateTimeOffset>().HaveConversion<DateTimeOffsetValueConverter>();
        configurationBuilder.Properties<EntityId>().HaveConversion<EntityIdValueConverter>();
        configurationBuilder.Properties<Name>().HaveConversion<NameValueConverter>();
    }
}
