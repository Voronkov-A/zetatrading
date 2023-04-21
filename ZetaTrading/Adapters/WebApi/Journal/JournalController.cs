using MediatR;
using ZetaTrading.Adapters.WebApi.Common;
using ZetaTrading.Adapters.WebApi.Journal.Queries;
using ZetaTrading.Domain.Common;

namespace ZetaTrading.Adapters.WebApi.Journal;

public class JournalController : JournalControllerBase
{
    private readonly IMediator _mediator;

    public JournalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<MRangeOfMJournalInfo> GetRange(
        int skip,
        int take,
        VJournalFilter body,
        CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(
            new GetAllJournalsQuery(body, new Pagination(Offset: skip, Limit: take)),
            cancellationToken);
    }

    public override async Task<MJournal> GetSingle(
        long id,
        CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetJournalQuery(new EntityId(id)), cancellationToken);
    }
}
