using ZetaTrading.Adapters.WebApi.ErrorHandling;

namespace ZetaTrading.Adapters.WebApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        return services.AddScoped<ExceptionHandler>();
    }
}
