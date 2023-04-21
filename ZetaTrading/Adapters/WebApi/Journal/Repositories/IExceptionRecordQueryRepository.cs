using ZetaTrading.Adapters.WebApi.Common;

namespace ZetaTrading.Adapters.WebApi.Journal.Repositories;

public interface IExceptionRecordQueryRepository
{
    Task<MRangeOfMJournalInfo> GetAll(
        VJournalFilter filter,
        Pagination pagination,
        CancellationToken cancellationToken);
}
