using ZetaTrading.Domain.Common;

namespace ZetaTrading.Domain.TreeNodes;

public interface ITreeNodeIdGenerator
{
    ValueTask<EntityId> GenerateId(CancellationToken cancellationToken);
}
