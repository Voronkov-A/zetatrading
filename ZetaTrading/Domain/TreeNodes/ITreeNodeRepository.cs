using ZetaTrading.Domain.Common;

namespace ZetaTrading.Domain.TreeNodes;

public interface ITreeNodeRepository
{
    Task<TreeNode?> Find(EntityId id, CancellationToken cancellationToken);

    Task<TreeNode?> Find(TreeNodeQuery query, CancellationToken cancellationToken);

    Task Add(TreeNode item, CancellationToken cancellationToken);

    Task Remove(TreeNode item, CancellationToken cancellationToken);
}
