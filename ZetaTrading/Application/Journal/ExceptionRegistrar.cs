using System.Transactions;
using ZetaTrading.Domain.Common.Exceptions;

namespace ZetaTrading.Application.Journal;

public class ExceptionRegistrar : IExceptionRegistrar
{
    private readonly IExceptionRecordIdGenerator _idGenerator;
    private readonly IExceptionRecordRepository _repository;

    public ExceptionRegistrar(IExceptionRecordIdGenerator idGenerator, IExceptionRecordRepository repository)
    {
        _idGenerator = idGenerator;
        _repository = repository;
    }

    public async Task<ExceptionRecord> Register(
        Exception exception,
        QueryDetails queryDetails,
        CancellationToken cancellationToken)
    {
        var timestamp = DateTimeOffset.UtcNow;
        var id = await _idGenerator.GenerateId(cancellationToken);
        // what does event id mean anyway?
        var eventId = new EventId(id.ToInt64());
        var type = exception is SecureException secureException ? secureException.Type : "Exception";
        var message = exception is SecureException
            ? exception.Message
            : $"Internal server error ID = {eventId} of event";
        var record = new ExceptionRecord(
            id: id,
            eventId: eventId,
            type: type,
            timestamp: timestamp,
            message: message,
            stackTrace: exception.StackTrace ?? "",
            details: queryDetails);
        using var transaction = new TransactionScope(
            TransactionScopeOption.RequiresNew,
            new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            },
            TransactionScopeAsyncFlowOption.Enabled);
        await _repository.Add(record, cancellationToken);
        transaction.Complete();
        return record;
    }
}
