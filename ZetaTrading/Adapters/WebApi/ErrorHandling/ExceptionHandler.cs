using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ZetaTrading.Application.Journal;

namespace ZetaTrading.Adapters.WebApi.ErrorHandling;

public class ExceptionHandler
{
    private readonly IExceptionRegistrar _exceptionRegistrar;
    private readonly IActionResultExecutor<ObjectResult> _actionResultExecutor;

    public ExceptionHandler(
        IExceptionRegistrar exceptionRegistrar,
        IActionResultExecutor<ObjectResult> actionResultExecutor)
    {
        _exceptionRegistrar = exceptionRegistrar;
        _actionResultExecutor = actionResultExecutor;
    }

    public async Task Handle(HttpContext context, CancellationToken cancellationToken)
    {
        var feature = context.Features.GetRequiredFeature<IExceptionHandlerPathFeature>();
        var exception = feature.Error;

        await using var ms = new MemoryStream();
        await context.Request.Body.CopyToAsync(ms, cancellationToken);
        var body = ms.ToArray();
        var queryDetails = new QueryDetails(path: context.Request.Path.ToString(), body: body);

        var record = await _exceptionRegistrar.Register(exception, queryDetails, cancellationToken);
        var error = record.ToErrorModel();
        await _actionResultExecutor.WriteResult(context, error, (int) HttpStatusCode.InternalServerError);
    }
}
