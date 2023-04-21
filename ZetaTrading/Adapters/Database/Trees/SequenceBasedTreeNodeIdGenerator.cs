using ZetaTrading.Adapters.Database.Common;
using ZetaTrading.Domain.Common;
using ZetaTrading.Domain.TreeNodes;

namespace ZetaTrading.Adapters.Database.Trees;

public class SequenceBasedTreeNodeIdGenerator : ITreeNodeIdGenerator
{
    internal const string SequenceName = "TreeNodeIdSequence";

    private readonly TreeContext _context;

    public SequenceBasedTreeNodeIdGenerator(TreeContext context)
    {
        _context = context;
    }

    public async ValueTask<EntityId> GenerateId(CancellationToken cancellationToken)
    {
        return await EntityIdSequence.Next(_context, TreeContext.SchemaName, SequenceName, cancellationToken);
    }
}
