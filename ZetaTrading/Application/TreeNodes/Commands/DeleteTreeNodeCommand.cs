using MediatR;
using ZetaTrading.Application.Common;
using ZetaTrading.Domain.Common;

namespace ZetaTrading.Application.TreeNodes.Commands;

public record DeleteTreeNodeCommand(Name TreeName, EntityId NodeId) : IRequest, ICommand;
