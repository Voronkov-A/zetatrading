namespace ZetaTrading.Application.Journal;

public class QueryDetails
{
    public QueryDetails(string path, IReadOnlyCollection<byte> body)
    {
        Path = path;
        Body = body.ToList();
    }

    public string Path { get; }

    public IReadOnlyCollection<byte> Body { get; }
}
