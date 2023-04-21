using ZetaTrading.Domain.Common.Exceptions;

namespace ZetaTrading.Domain.TreeNodes.Exceptions;

public class DuplicatedNodeNameException : SecureException
{
    public DuplicatedNodeNameException(string message) : base(message)
    {
    }

    public override string Type => "DuplicatedNodeName";
}
