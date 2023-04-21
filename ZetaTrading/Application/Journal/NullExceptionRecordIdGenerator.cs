using ZetaTrading.Domain.Common;

namespace ZetaTrading.Application.Journal;

public class NullExceptionRecordIdGenerator : IExceptionRecordIdGenerator
{
    public ValueTask<EntityId> GenerateId(CancellationToken cancellationToken)
    {
        return ValueTask.FromResult(new EntityId());
    }
}
