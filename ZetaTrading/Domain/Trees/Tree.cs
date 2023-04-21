using ZetaTrading.Domain.Common;
using ZetaTrading.Domain.TreeNodes;

namespace ZetaTrading.Domain.Trees;

public class Tree
{
    public Tree(TreeNode root)
    {
        Root = root;
    }

    public EntityId Id => Root.Id;

    public TreeNode Root { get; }
}
