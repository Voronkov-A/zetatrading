using Microsoft.EntityFrameworkCore;
using ZetaTrading.Adapters.WebApi.Trees;
using ZetaTrading.Adapters.WebApi.Trees.Repositories;
using ZetaTrading.Domain.Common;
using ZetaTrading.Domain.Trees;

namespace ZetaTrading.Adapters.Database.Trees;

public class TreeRepository : ITreeRepository, ITreeQueryRepository
{
    private readonly TreeContext _context;

    public TreeRepository(TreeContext context)
    {
        _context = context;
    }

    public async Task Add(Tree item, CancellationToken cancellationToken)
    {
        await _context.TreeNodes.AddAsync(item.Root, cancellationToken);
    }

    public async Task<MNode?> FindTree(Name name, CancellationToken cancellationToken)
    {
        var nodes = await _context.TreeNodes
            .AsNoTracking()
            .Include(x => x.Parent)
            .Where(x => x.Root.Name == name)
            .Select(x => new
            {
                Domain = x,
                Dto = new MNode
                {
                    Id = x.Id.ToInt64(),
                    Name = x.Name.ToString(),
                    Children = new SortedSet<MNode>(new MNodeComparer())
                }
            })
            .ToDictionaryAsync(x => x.Domain.Id, cancellationToken);

        MNode? root = null;

        foreach (var node in nodes.Values)
        {
            if (node.Domain.Parent == null)
            {
                root = node.Dto;
            }
            else
            {
                var parent = nodes[node.Domain.Parent.Id];
                parent.Dto.Children.Add(node.Dto);
            }
        }

        return root;
    }

    private class MNodeComparer : IComparer<MNode>
    {
        public int Compare(MNode? x, MNode? y)
        {
            return string.Compare(x?.Name, y?.Name, StringComparison.Ordinal);
        }
    }
}
