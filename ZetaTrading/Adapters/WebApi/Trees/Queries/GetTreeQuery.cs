using MediatR;
using ZetaTrading.Domain.Common;

namespace ZetaTrading.Adapters.WebApi.Trees.Queries;

public record GetTreeQuery(Name TreeName) : IRequest<MNode?>;
