using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ZetaTrading.Adapters.WebApi.ErrorHandling;

public static class ActionResultExecutorExtensions
{
    public static Task WriteResult(
        this IActionResultExecutor<ObjectResult> self,
        HttpContext context,
        object result,
        int? statusCode)
    {
        var response = new ObjectResult(result)
        {
            StatusCode = statusCode ?? context.Response.StatusCode,
            ContentTypes = new MediaTypeCollection
            {
                MediaTypeNames.Application.Json
            },
            DeclaredType = result.GetType()
        };

        var actionContext = new ActionContext(
            context,
            context.GetRouteData(),
            new ActionDescriptor());

        return self.ExecuteAsync(actionContext, response);
    }
}
