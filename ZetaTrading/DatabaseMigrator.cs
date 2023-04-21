using Microsoft.EntityFrameworkCore;
using ZetaTrading.Adapters.Database.Journal;
using ZetaTrading.Adapters.Database.Trees;

namespace ZetaTrading;

public class DatabaseMigrator : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        await scope.ServiceProvider.GetRequiredService<JournalContext>().Database.MigrateAsync(cancellationToken);
        await scope.ServiceProvider.GetRequiredService<TreeContext>().Database.MigrateAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
