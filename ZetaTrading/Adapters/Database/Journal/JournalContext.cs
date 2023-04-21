using Microsoft.EntityFrameworkCore;
using ZetaTrading.Adapters.Database.Common.Converters;
using ZetaTrading.Adapters.Database.Journal.Configurations;
using ZetaTrading.Adapters.Database.Journal.Converters;
using ZetaTrading.Application.Journal;
using ZetaTrading.Domain.Common;
using EventId = ZetaTrading.Application.Journal.EventId;

namespace ZetaTrading.Adapters.Database.Journal;

public class JournalContext : DbContext
{
    public const string SchemaName = "journal";

    public JournalContext(DbContextOptions<JournalContext> options) : base(options)
    {
    }

    public DbSet<ExceptionRecord> ExceptionRecords { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaName);
        modelBuilder.ApplyConfiguration(new ExceptionRecordConfiguration());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<DateTimeOffset>().HaveConversion<DateTimeOffsetValueConverter>();
        configurationBuilder.Properties<EntityId>().HaveConversion<EntityIdValueConverter>();
        configurationBuilder.Properties<EventId>().HaveConversion<EventIdValueConverter>();
        configurationBuilder.Properties<QueryDetails>()
            .HaveConversion<JsonValueConverter<QueryDetails>>()
            .HaveColumnType("jsonb");
    }
}
