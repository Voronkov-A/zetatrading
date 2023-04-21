using MediatR;
using ZetaTrading.Adapters.WebApi.Journal.Exceptions;
using ZetaTrading.Application.Journal;

namespace ZetaTrading.Adapters.WebApi.Journal.Queries;

public class GetJournalQueryHandler : IRequestHandler<GetJournalQuery, MJournal>
{
    private readonly IExceptionRecordRepository _repository;

    public GetJournalQueryHandler(IExceptionRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task<MJournal> Handle(GetJournalQuery request, CancellationToken cancellationToken)
    {
        var record = await _repository.Find(request.JournalId, cancellationToken);

        if (record == null)
        {
            throw new JournalNotFoundException($"Journal with id '{request.JournalId}' has not been found.");
        }

        return record.ToMJournal();
    }
}
