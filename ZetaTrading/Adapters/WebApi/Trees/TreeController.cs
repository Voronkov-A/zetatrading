using MediatR;
using ZetaTrading.Adapters.WebApi.Trees.Queries;
using ZetaTrading.Application.Trees.Commands;
using ZetaTrading.Domain.Common;

namespace ZetaTrading.Adapters.WebApi.Trees;

public class TreeController : TreeControllerBase
{
    private readonly IMediator _mediator;

    public TreeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<MNode> Get(string treeName, CancellationToken cancellationToken = default)
    {
        var name = new Name(treeName);
        var dto = await _mediator.Send(new GetTreeQuery(name), cancellationToken);

        if (dto != null)
        {
            return dto;
        }

        var tree = await _mediator.Send(new CreateTreeCommand(name), cancellationToken);
        return tree.ToMNode();
    }
}
