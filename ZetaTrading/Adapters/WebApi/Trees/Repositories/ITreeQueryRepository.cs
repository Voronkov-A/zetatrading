using ZetaTrading.Domain.Common;

namespace ZetaTrading.Adapters.WebApi.Trees.Repositories;

public interface ITreeQueryRepository
{
    Task<MNode?> FindTree(Name name, CancellationToken cancellationToken);
}
