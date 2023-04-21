using MediatR;
using ZetaTrading.Domain.Common;

namespace ZetaTrading.Adapters.WebApi.Journal.Queries;

public record GetJournalQuery(EntityId JournalId) : IRequest<MJournal>;
