using MediatR;
using ZetaTrading.Domain.Trees;

namespace ZetaTrading.Application.Trees.Commands;

public class CreateTreeCommandHandler : IRequestHandler<CreateTreeCommand, Tree>
{
    private readonly ITreeFactory _factory;
    private readonly ITreeRepository _repository;

    public CreateTreeCommandHandler(ITreeFactory factory, ITreeRepository repository)
    {
        _factory = factory;
        _repository = repository;
    }

    public async Task<Tree> Handle(CreateTreeCommand command, CancellationToken cancellationToken)
    {
        var tree = await _factory.CreateTree(command.TreeName, cancellationToken);
        await _repository.Add(tree, cancellationToken);
        return tree;
    }
}
