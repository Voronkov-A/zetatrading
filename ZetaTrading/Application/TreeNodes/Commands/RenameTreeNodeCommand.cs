using MediatR;
using ZetaTrading.Application.Common;
using ZetaTrading.Domain.Common;

namespace ZetaTrading.Application.TreeNodes.Commands;

public record RenameTreeNodeCommand(Name TreeName, EntityId NodeId, Name NewNodeName) : IRequest, ICommand;
