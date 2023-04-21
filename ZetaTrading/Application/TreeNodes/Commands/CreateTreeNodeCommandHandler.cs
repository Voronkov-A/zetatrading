using MediatR;
using ZetaTrading.Application.TreeNodes.Exceptions;
using ZetaTrading.Domain.TreeNodes;

namespace ZetaTrading.Application.TreeNodes.Commands;

public class CreateTreeNodeCommandHandler : IRequestHandler<CreateTreeNodeCommand>
{
    private readonly ITreeNodeFactory _factory;
    private readonly ITreeNodeRepository _repository;

    public CreateTreeNodeCommandHandler(ITreeNodeFactory factory, ITreeNodeRepository repository)
    {
        _factory = factory;
        _repository = repository;
    }

    public async Task Handle(CreateTreeNodeCommand command, CancellationToken cancellationToken)
    {
        var parentNode = await _repository.Find(command.ParentNodeId, cancellationToken);

        if (parentNode == null || parentNode.Root.Name != command.TreeName)
        {
            throw new TreeNodeNotFoundException(
                $"Tree node with id '{command.ParentNodeId}' and root name '{command.TreeName}' has not been found.");
        }

        var node = await _factory.CreateChildNode(parentNode, command.NodeName, cancellationToken);
        await _repository.Add(node, cancellationToken);
    }
}
