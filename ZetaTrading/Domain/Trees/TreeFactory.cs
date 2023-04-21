using ZetaTrading.Domain.Common;
using ZetaTrading.Domain.TreeNodes;

namespace ZetaTrading.Domain.Trees;

public class TreeFactory : ITreeFactory
{
    private readonly ITreeNodeIdGenerator _idGenerator;

    public TreeFactory(ITreeNodeIdGenerator idGenerator)
    {
        _idGenerator = idGenerator;
    }

    public async ValueTask<Tree> CreateTree(Name name, CancellationToken cancellationToken)
    {
        var id = await _idGenerator.GenerateId(cancellationToken);
        var root = new TreeNode(id, name);
        return new Tree(root);
    }
}
