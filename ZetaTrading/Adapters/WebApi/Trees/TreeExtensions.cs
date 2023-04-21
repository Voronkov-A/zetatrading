using ZetaTrading.Domain.TreeNodes;
using ZetaTrading.Domain.Trees;

namespace ZetaTrading.Adapters.WebApi.Trees;

public static class TreeExtensions
{
    public static MNode ToMNode(this Tree tree)
    {
        var nodes = new Queue<(TreeNode Domain, MNode Dto)>();
        var rootDto = ToMNodeWithoutChildren(tree.Root);
        nodes.Enqueue((tree.Root, rootDto));

        while (nodes.TryDequeue(out var node))
        {
            foreach (var child in node.Domain.Children)
            {
                var childDto = ToMNodeWithoutChildren(child);
                node.Dto.Children.Add(childDto);
                nodes.Enqueue((child, childDto));
            }
        }

        return rootDto;
    }

    private static MNode ToMNodeWithoutChildren(TreeNode node)
    {
        return new MNode
        {
            Id = node.Id.ToInt64(),
            Name = node.Name.ToString(),
            Children = new List<MNode>(node.Children.Count)
        };
    }
}
