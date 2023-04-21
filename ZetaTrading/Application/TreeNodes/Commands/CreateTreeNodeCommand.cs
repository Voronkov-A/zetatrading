using MediatR;
using ZetaTrading.Application.Common;
using ZetaTrading.Domain.Common;

namespace ZetaTrading.Application.TreeNodes.Commands;

public record CreateTreeNodeCommand(Name TreeName, EntityId ParentNodeId, Name NodeName) : IRequest, ICommand;
