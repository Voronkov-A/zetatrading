using MediatR;
using ZetaTrading.Adapters.WebApi.Common;

namespace ZetaTrading.Adapters.WebApi.Journal.Queries;

public record GetAllJournalsQuery(VJournalFilter Filter, Pagination Pagination) : IRequest<MRangeOfMJournalInfo>;
