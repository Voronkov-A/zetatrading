using ZetaTrading.Adapters.Database;
using ZetaTrading.Adapters.Database.Common;
using ZetaTrading.Adapters.WebApi;
using ZetaTrading.Adapters.WebApi.ErrorHandling;
using ZetaTrading.Application;
using ZetaTrading.Domain;

namespace ZetaTrading;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDomain();
        services.AddApplication();
        services.AddWebApi();
        services.AddDatabase(
            _configuration.GetSection("persistence").Get<PersistenceOptions>()
            ?? throw new SystemException("Persistence section is required."));
        services.AddHostedService<DatabaseMigrator>();
    }

    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {
        app.UseExceptionHandler(builder => builder
            .Run(async context => await context
                .RequestServices.GetRequiredService<ExceptionHandler>()
                .Handle(context, context.RequestAborted)));
        app.UseRouting();
        app.UseEndpoints(x => x.MapControllers());
    }
}
