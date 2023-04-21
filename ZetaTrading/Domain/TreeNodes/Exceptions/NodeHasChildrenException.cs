using ZetaTrading.Domain.Common.Exceptions;

namespace ZetaTrading.Domain.TreeNodes.Exceptions;

public class NodeHasChildrenException : SecureException
{
    public NodeHasChildrenException(string message) : base(message)
    {
    }

    public override string Type => "NodeHasChildren";
}
