using ZetaTrading.Adapters.Database.Common;
using ZetaTrading.Application.Journal;
using ZetaTrading.Domain.Common;

namespace ZetaTrading.Adapters.Database.Journal;

public class SequenceBasedExceptionRecordIdGenerator : IExceptionRecordIdGenerator
{
    internal const string SequenceName = "ExceptionRecordIdSequence";

    private readonly JournalContext _context;

    public SequenceBasedExceptionRecordIdGenerator(JournalContext context)
    {
        _context = context;
    }

    public async ValueTask<EntityId> GenerateId(CancellationToken cancellationToken)
    {
        return await EntityIdSequence.Next(_context, JournalContext.SchemaName, SequenceName, cancellationToken);
    }
}
