namespace ZetaTrading.Domain.Common.Exceptions;

public class SecureException : ApplicationException
{
    protected SecureException(string message) : base(message)
    {
    }

    public virtual string Type => "Secure";
}
