using ZetaTrading.Domain.TreeNodes;
using ZetaTrading.Domain.Trees;

namespace ZetaTrading.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services
            .AddSingleton<ITreeNodeFactory, TreeNodeFactory>()
            .AddSingleton<ITreeNodeIdGenerator, NullTreeNodeIdGenerator>()
            .AddSingleton<ITreeFactory, TreeFactory>();
    }
}
