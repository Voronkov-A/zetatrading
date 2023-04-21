using ZetaTrading.Domain.Common;

namespace ZetaTrading.Domain.TreeNodes;

public interface ITreeNodeFactory
{
    ValueTask<TreeNode> CreateChildNode(TreeNode parentNode, Name name, CancellationToken cancellationToken);
}
