using ZetaTrading.Domain.Common;
using ZetaTrading.Domain.TreeNodes.Exceptions;

namespace ZetaTrading.Domain.TreeNodes;

public class TreeNode
{
    private readonly List<TreeNode> _children;

    public TreeNode(EntityId id, Name name, TreeNode parent, TreeNode root)
    {
        Id = id;
        Name = name;
        Parent = parent;
        Root = root;
        _children = new List<TreeNode>();
    }

    public TreeNode(EntityId id, Name name)
    {
        Id = id;
        Name = name;
        Root = this;
        _children = new List<TreeNode>();
    }

    private TreeNode()
    {
        Root = null!;
        _children = null!;
    }

    public EntityId Id { get; }

    public Name Name { get; private set; }

    public TreeNode? Parent { get; private set; }

    public TreeNode Root { get; }

    public IReadOnlyCollection<TreeNode> Children => _children;

    public TreeNode CreateChild(EntityId id, Name name)
    {
        if (_children.Any(x => x.Name == name))
        {
            throw new DuplicatedNodeNameException($"Child with name '{name}' already exists.");
        }

        var child = new TreeNode(id, name, this, Root);
        _children.Add(child);
        return child;
    }

    public void RenameChild(EntityId id, Name name)
    {
        if (_children.Any(x => x.Name == name && x.Id != id))
        {
            throw new DuplicatedNodeNameException($"Child with name '{name}' already exists.");
        }

        var child = _children.First(x => x.Id == id);
        child.Name = name;
    }

    public void Delete()
    {
        if (_children.Count > 0)
        {
            throw new NodeHasChildrenException("You have to delete all children nodes first.");
        }

        Parent = null;
    }
}
