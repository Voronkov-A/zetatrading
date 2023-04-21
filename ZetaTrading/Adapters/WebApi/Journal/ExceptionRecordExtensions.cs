using ZetaTrading.Application.Journal;

namespace ZetaTrading.Adapters.WebApi.Journal;

public static class ExceptionRecordExtensions
{
    public static MJournal ToMJournal(this ExceptionRecord exceptionRecord)
    {
        return new MJournal
        {
            Id = exceptionRecord.Id.ToInt64(),
            CreatedAt = exceptionRecord.Timestamp,
            EventId = exceptionRecord.EventId.ToInt64(),
            Text = exceptionRecord.Message
        };
    }
}
