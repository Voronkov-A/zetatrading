using ZetaTrading.Domain.Common;

namespace ZetaTrading.Domain.TreeNodes;

public class TreeNodeFactory : ITreeNodeFactory
{
    private readonly ITreeNodeIdGenerator _idGenerator;

    public TreeNodeFactory(ITreeNodeIdGenerator idGenerator)
    {
        _idGenerator = idGenerator;
    }

    public async ValueTask<TreeNode> CreateChildNode(TreeNode parentNode, Name name, CancellationToken cancellationToken)
    {
        var id = await _idGenerator.GenerateId(cancellationToken);
        return parentNode.CreateChild(id, name);
    }
}
