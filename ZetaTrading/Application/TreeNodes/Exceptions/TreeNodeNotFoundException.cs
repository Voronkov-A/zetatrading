using ZetaTrading.Domain.Common.Exceptions;

namespace ZetaTrading.Application.TreeNodes.Exceptions;

public class TreeNodeNotFoundException : SecureException
{
    public TreeNodeNotFoundException(string message) : base(message)
    {
    }

    public override string Type => "TreeNodeNotFound";
}
