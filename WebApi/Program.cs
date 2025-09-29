using Business;
using Entities;
using FlaskFinder;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi.Apis;

namespace WebApi;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        builder.Services.AddDbContext<FlaskFinderDbContext>((sp, options) =>
        {
            var connectionString = builder.Configuration.GetConnectionString("Postgres");
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        builder.Logging.AddSimpleConsole(c => c.SingleLine = true);

        builder.Services.AddTransient<WineService>();

        var app = builder.Build();

        await using var Scope = app.Services.CreateAsyncScope();
        var DbContext = Scope.ServiceProvider.GetRequiredService<FlaskFinderDbContext>();

        var canConnect = await DbContext.Database.CanConnectAsync();
        app.Logger.LogInformation("Can connect to database: {CanConnect}", canConnect);

        app.MapGroup("api")
            .RegisterWineApi();

        app.Run();
    }
}

[JsonSerializable(typeof(Wine[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
