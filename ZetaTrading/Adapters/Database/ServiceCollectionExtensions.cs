using Microsoft.EntityFrameworkCore;
using ZetaTrading.Adapters.Database.Common;
using ZetaTrading.Adapters.Database.Journal;
using ZetaTrading.Adapters.Database.Trees;
using ZetaTrading.Adapters.WebApi.Journal.Repositories;
using ZetaTrading.Adapters.WebApi.Trees.Repositories;
using ZetaTrading.Application.Common;
using ZetaTrading.Application.Journal;
using ZetaTrading.Domain.TreeNodes;
using ZetaTrading.Domain.Trees;

namespace ZetaTrading.Adapters.Database;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, PersistenceOptions options)
    {
        return services
            .AddDbContext<JournalContext>(
                x => x.UseNpgsql(
                    options.ConnectionString,
                    c => c.MigrationsHistoryTable(
                        tableName: "__EFMigrationsHistory",
                        schema: JournalContext.SchemaName)),
                contextLifetime: ServiceLifetime.Scoped,
                optionsLifetime: ServiceLifetime.Singleton)
            .AddScoped<ExceptionRecordRepository>()
            .AddScoped<IExceptionRecordRepository>(sp => sp.GetRequiredService<ExceptionRecordRepository>())
            .AddScoped<IExceptionRecordQueryRepository>(sp => sp.GetRequiredService<ExceptionRecordRepository>())
            .AddScoped<IExceptionRecordIdGenerator, SequenceBasedExceptionRecordIdGenerator>()
            .AddDbContext<TreeContext>(
                x => x.UseNpgsql(
                    options.ConnectionString,
                    c => c.MigrationsHistoryTable(
                        tableName: "__EFMigrationsHistory",
                        schema: TreeContext.SchemaName)),
                contextLifetime: ServiceLifetime.Scoped,
                optionsLifetime: ServiceLifetime.Singleton)
            .AddScoped<ITreeNodeRepository, TreeNodeRepository>()
            .AddScoped<TreeRepository>()
            .AddScoped<ITreeRepository>(sp => sp.GetRequiredService<TreeRepository>())
            .AddScoped<ITreeQueryRepository>(sp => sp.GetRequiredService<TreeRepository>())
            .AddScoped<ITreeNodeIdGenerator, SequenceBasedTreeNodeIdGenerator>()
            .AddScoped<IUnitOfWork, TreeContextUnitOfWork>();
    }
}
