namespace ZetaTrading.Application.Journal;

public interface IExceptionRegistrar
{
    Task<ExceptionRecord> Register(Exception exception, QueryDetails queryDetails, CancellationToken cancellationToken);
}
