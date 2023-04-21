using ZetaTrading.Domain.Common;

namespace ZetaTrading.Application.Journal;

public interface IExceptionRecordRepository
{
    Task Add(ExceptionRecord item, CancellationToken cancellationToken);

    Task<ExceptionRecord?> Find(EntityId id, CancellationToken cancellationToken);
}
