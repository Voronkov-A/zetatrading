using ZetaTrading.Application.Common;

namespace ZetaTrading.Adapters.Database.Trees;

public class TreeContextUnitOfWork : IUnitOfWork
{
    private readonly TreeContext _treeContext;

    public TreeContextUnitOfWork(TreeContext treeContext)
    {
        _treeContext = treeContext;
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        await _treeContext.SaveChangesAsync(cancellationToken);
    }
}