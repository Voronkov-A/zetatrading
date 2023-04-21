using MediatR;
using ZetaTrading.Adapters.WebApi.Journal.Repositories;

namespace ZetaTrading.Adapters.WebApi.Journal.Queries;

public class GetAllJournalsQueryHandler : IRequestHandler<GetAllJournalsQuery, MRangeOfMJournalInfo>
{
    private readonly IExceptionRecordQueryRepository _repository;

    public GetAllJournalsQueryHandler(IExceptionRecordQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<MRangeOfMJournalInfo> Handle(GetAllJournalsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAll(request.Filter, request.Pagination, cancellationToken);
    }
}
