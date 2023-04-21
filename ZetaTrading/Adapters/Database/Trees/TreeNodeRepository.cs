using Microsoft.EntityFrameworkCore;
using ZetaTrading.Domain.Common;
using ZetaTrading.Domain.TreeNodes;

namespace ZetaTrading.Adapters.Database.Trees;

public class TreeNodeRepository : ITreeNodeRepository
{
    private readonly TreeContext _context;

    public TreeNodeRepository(TreeContext context)
    {
        _context = context;
    }

    public async Task<TreeNode?> Find(EntityId id, CancellationToken cancellationToken)
    {
        return await _context.TreeNodes
            .Include(x => x.Parent)
            .Include(x => x.Root)
            .Include(x => x.Children)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<TreeNode?> Find(TreeNodeQuery query, CancellationToken cancellationToken)
    {
        return await _context.TreeNodes
            .Include(x => x.Parent)
            .Include(x => x.Root)
            .Include(x => x.Children)
            .SingleOrDefaultAsync(x => x.Children.Any(child => child.Id == query.ChildId), cancellationToken);
    }

    public async Task Add(TreeNode item, CancellationToken cancellationToken)
    {
        await _context.TreeNodes.AddAsync(item, cancellationToken);
    }

    public Task Remove(TreeNode item, CancellationToken cancellationToken)
    {
        _context.TreeNodes.Remove(item);
        return Task.CompletedTask;
    }
}
