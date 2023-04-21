using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ZetaTrading.Adapters.WebApi.Common;
using ZetaTrading.Adapters.WebApi.Journal;
using ZetaTrading.Adapters.WebApi.Journal.Repositories;
using ZetaTrading.Application.Journal;
using ZetaTrading.Domain.Common;

namespace ZetaTrading.Adapters.Database.Journal;

public class ExceptionRecordRepository : IExceptionRecordRepository, IExceptionRecordQueryRepository
{
    private readonly JournalContext _context;

    public ExceptionRecordRepository(JournalContext context)
    {
        _context = context;
    }

    public async Task Add(ExceptionRecord item, CancellationToken cancellationToken)
    {
        await _context.ExceptionRecords.AddAsync(item, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<ExceptionRecord?> Find(EntityId id, CancellationToken cancellationToken)
    {
        return await _context.ExceptionRecords.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<MRangeOfMJournalInfo> GetAll(
        VJournalFilter filter,
        Pagination pagination,
        CancellationToken cancellationToken)
    {
        var query = _context.ExceptionRecords.AsNoTracking();

        if (filter.From != null)
        {
            query = query.Where(x => x.Timestamp >= filter.From);
        }

        if (filter.To != null)
        {
            query = query.Where(x => x.Timestamp < filter.To);
        }

        if (filter.Search != null)
        {
            query = query.Where(x => x.Message.Contains(filter.Search));
        }

        var items = await query
            .OrderBy(x => x.Id)
            .Skip(pagination.Offset)
            .Take(pagination.Limit)
            .Select(x => new MJournalInfo
            {
                Id = x.Id.ToInt64(),
                CreatedAt = x.Timestamp,
                EventId = x.EventId.ToInt64()
            })
            .ToListAsync(cancellationToken);
        return new MRangeOfMJournalInfo()
        {
            Items = items,
            Skip = pagination.Offset,
            Count = pagination.Limit
        };
    }
}
