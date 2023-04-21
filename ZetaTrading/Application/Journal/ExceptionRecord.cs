using ZetaTrading.Domain.Common;

namespace ZetaTrading.Application.Journal;

public class ExceptionRecord
{
    public ExceptionRecord(
        EntityId id,
        EventId eventId,
        string type,
        DateTimeOffset timestamp,
        string message,
        string stackTrace,
        QueryDetails details)
    {
        Id = id;
        EventId = eventId;
        Type = type;
        Timestamp = timestamp;
        Message = message;
        StackTrace = stackTrace;
        Details = details;
    }

    public EntityId Id { get; }

    public EventId EventId { get; }

    public string Type { get; }

    public DateTimeOffset Timestamp { get; }

    public string Message { get; }

    public string StackTrace { get; }

    public QueryDetails Details { get; }
}
