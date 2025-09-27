using FlaskFinder;
using System.Text.Json.Serialization;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        var app = builder.Build();

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
