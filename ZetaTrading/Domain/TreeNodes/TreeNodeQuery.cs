using ZetaTrading.Domain.Common;

namespace ZetaTrading.Domain.TreeNodes;

public readonly struct TreeNodeQuery
{
    private TreeNodeQuery(EntityId childId)
    {
        ChildId = childId;
    }

    public EntityId ChildId { get; }

    public static TreeNodeQuery ByChildId(EntityId childId)
    {
        return new TreeNodeQuery(childId);
    }
}
