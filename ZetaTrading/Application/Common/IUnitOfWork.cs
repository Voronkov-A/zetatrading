namespace ZetaTrading.Application.Common;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken);
}
