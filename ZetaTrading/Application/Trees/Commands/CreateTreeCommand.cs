using MediatR;
using ZetaTrading.Application.Common;
using ZetaTrading.Domain.Common;
using ZetaTrading.Domain.Trees;

namespace ZetaTrading.Application.Trees.Commands;

public record CreateTreeCommand(Name TreeName) : IRequest<Tree>, ICommand;
