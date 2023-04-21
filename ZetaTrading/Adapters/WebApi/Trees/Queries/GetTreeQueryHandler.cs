using MediatR;
using ZetaTrading.Adapters.WebApi.Trees.Repositories;

namespace ZetaTrading.Adapters.WebApi.Trees.Queries;

public class GetTreeQueryHandler : IRequestHandler<GetTreeQuery, MNode?>
{
    private readonly ITreeQueryRepository _repository;

    public GetTreeQueryHandler(ITreeQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<MNode?> Handle(GetTreeQuery query, CancellationToken cancellationToken)
    {
        return await _repository.FindTree(query.TreeName, cancellationToken);
    }
}
