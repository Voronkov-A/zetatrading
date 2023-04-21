using ZetaTrading.Domain.Common;

namespace ZetaTrading.Domain.Trees;

public interface ITreeFactory
{
    ValueTask<Tree> CreateTree(Name name, CancellationToken cancellationToken);
}
