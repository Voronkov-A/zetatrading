using ZetaTrading.Application.Common;
using ZetaTrading.Application.Journal;

namespace ZetaTrading.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddMediatR(c => c
                .RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly)
                .AddOpenBehavior(typeof(UnitOfWorkPipelineBehavior<,>), ServiceLifetime.Scoped))
            .AddScoped<IExceptionRegistrar, ExceptionRegistrar>()
            .AddSingleton<IExceptionRecordIdGenerator, NullExceptionRecordIdGenerator>();
    }
}
