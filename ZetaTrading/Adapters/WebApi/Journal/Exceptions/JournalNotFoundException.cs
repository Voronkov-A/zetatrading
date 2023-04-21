using ZetaTrading.Domain.Common.Exceptions;

namespace ZetaTrading.Adapters.WebApi.Journal.Exceptions;

public class JournalNotFoundException : SecureException
{
    public JournalNotFoundException(string message) : base(message)
    {
    }

    public override string Type => "JournalNotFound";
}
