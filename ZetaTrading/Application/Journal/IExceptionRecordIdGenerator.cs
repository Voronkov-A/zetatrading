using ZetaTrading.Domain.Common;

namespace ZetaTrading.Application.Journal;

public interface IExceptionRecordIdGenerator
{
    ValueTask<EntityId> GenerateId(CancellationToken cancellationToken);
}
