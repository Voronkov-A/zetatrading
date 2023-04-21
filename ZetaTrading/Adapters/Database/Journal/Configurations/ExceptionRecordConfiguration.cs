using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZetaTrading.Application.Journal;

namespace ZetaTrading.Adapters.Database.Journal.Configurations;

public class ExceptionRecordConfiguration : IEntityTypeConfiguration<ExceptionRecord>
{
    public void Configure(EntityTypeBuilder<ExceptionRecord> builder)
    {
        builder.ToTable("ExceptionRecords");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.EventId).IsRequired();
        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.Timestamp).IsRequired();
        builder.Property(x => x.Message).IsRequired();
        builder.Property(x => x.StackTrace).IsRequired();
        builder.Property(x => x.Details).IsRequired();
        builder.HasIndex(x => x.Timestamp);
    }
}
