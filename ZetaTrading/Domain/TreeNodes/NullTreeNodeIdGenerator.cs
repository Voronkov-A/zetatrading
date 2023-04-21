using ZetaTrading.Domain.Common;

namespace ZetaTrading.Domain.TreeNodes;

public class NullTreeNodeIdGenerator : ITreeNodeIdGenerator
{
    public ValueTask<EntityId> GenerateId(CancellationToken cancellationToken)
    {
        return ValueTask.FromResult(new EntityId());
    }
}
