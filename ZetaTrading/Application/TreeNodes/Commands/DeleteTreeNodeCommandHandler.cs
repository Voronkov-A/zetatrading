using MediatR;
using ZetaTrading.Application.TreeNodes.Exceptions;
using ZetaTrading.Domain.TreeNodes;

namespace ZetaTrading.Application.TreeNodes.Commands;

public class DeleteTreeNodeCommandHandler : IRequestHandler<DeleteTreeNodeCommand>
{
    private readonly ITreeNodeRepository _repository;

    public DeleteTreeNodeCommandHandler(ITreeNodeRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteTreeNodeCommand command, CancellationToken cancellationToken)
    {
        var node = await _repository.Find(command.NodeId, cancellationToken);

        if (node == null || node.Root.Name != command.TreeName)
        {
            throw new TreeNodeNotFoundException(
                $"Tree node with id '{command.NodeId}' and root name '{command.TreeName}' has not been found.");
        }

        node.Delete();
        await _repository.Remove(node, cancellationToken);
    }
}
