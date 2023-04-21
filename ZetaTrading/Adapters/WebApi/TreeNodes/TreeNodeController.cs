using MediatR;
using ZetaTrading.Application.TreeNodes.Commands;
using ZetaTrading.Domain.Common;

namespace ZetaTrading.Adapters.WebApi.TreeNodes;

public class TreeNodeController : TreeNodeControllerBase
{
    private readonly IMediator _mediator;

    public TreeNodeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task Create(
        string treeName,
        long parentNodeId,
        string nodeName,
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new CreateTreeNodeCommand(new Name(treeName), new EntityId(parentNodeId), new Name(nodeName)),
            cancellationToken);
    }

    public override async Task Delete(
        string treeName,
        long nodeId,
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new DeleteTreeNodeCommand(new Name(treeName), new EntityId(nodeId)), cancellationToken);
    }

    public override async Task Rename(
        string treeName,
        long nodeId,
        string newNodeName,
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new RenameTreeNodeCommand(new Name(treeName), new EntityId(nodeId), new Name(newNodeName)),
            cancellationToken);
    }
}
