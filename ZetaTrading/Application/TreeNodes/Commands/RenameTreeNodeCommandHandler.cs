using MediatR;
using ZetaTrading.Application.TreeNodes.Exceptions;
using ZetaTrading.Domain.TreeNodes;

namespace ZetaTrading.Application.TreeNodes.Commands;

public class RenameTreeNodeCommandHandler : IRequestHandler<RenameTreeNodeCommand>
{
    private readonly ITreeNodeRepository _repository;

    public RenameTreeNodeCommandHandler(ITreeNodeRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(RenameTreeNodeCommand command, CancellationToken cancellationToken)
    {
        var parentNode = await _repository.Find(TreeNodeQuery.ByChildId(command.NodeId), cancellationToken);

        if (parentNode == null)
        {
            var node = await _repository.Find(command.NodeId, cancellationToken);

            if (node != null)
            {
                throw new CannotRenameRootNodeException("Couldn't rename root node.");
            }
        }

        if (parentNode == null || parentNode.Root.Name != command.TreeName)
        {
            throw new TreeNodeNotFoundException(
                $"Tree node with id '{command.NodeId}' and root name '{command.TreeName}' has not been found.");
        }

        parentNode.RenameChild(command.NodeId, command.NewNodeName);
    }
}
