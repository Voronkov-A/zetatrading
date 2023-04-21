using ZetaTrading.Domain.Common.Exceptions;

namespace ZetaTrading.Application.TreeNodes.Exceptions;

public class CannotRenameRootNodeException : SecureException
{
    public CannotRenameRootNodeException(string message) : base(message)
    {
    }

    public override string Type => "CannotRenameRootNode";
}
