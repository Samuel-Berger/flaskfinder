using FlaskFinder;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi.Setup;

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

        builder.Services.AddDbContext<Database>((sp, options) =>
        {
            var connectionString = builder.Configuration.GetConnectionString("Postgres");

            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        builder.Logging.AddSimpleConsole(c => c.SingleLine = true);

        var app = builder.Build();

        await using var scope = app.Services.CreateAsyncScope();
        var db = scope.ServiceProvider.GetRequiredService<Database>();
        var canConnect = await db.Database.CanConnectAsync();
        app.Logger.LogInformation("Can connect to database: {CanConnect}", canConnect);

        var allWines = new Wine[]
        {
            new ()
            {
                Id = 1,
                Producer= "Clotilde Davenne",
                Label = "Brut Extra Crémant de Bourgogne",
                Vintage = null,
                AlcoholByVolume = new decimal(12.5),
                Container = Container.Bottle,
                Grapes = new List<Blend>()
                {
                    new Blend(Grape.PinotNoir, 60),
                    new Blend(Grape.Chardonnay, 40),
                }
            }
        };

        var winesApi = app.MapGroup("/wines");

        winesApi.MapGet("/", () => allWines);

        winesApi.MapGet("/{id}", (int id) =>
            allWines.FirstOrDefault(a => a.Id == id) is { } wine
                ? Results.Ok(wine)
                : Results.NotFound());

        app.Run();
    }
}

[JsonSerializable(typeof(Wine[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
