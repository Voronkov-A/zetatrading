namespace ZetaTrading.Domain.Trees;

public interface ITreeRepository
{
    Task Add(Tree item, CancellationToken cancellationToken);
}
