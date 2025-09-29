using Business;
using FlaskFinder;

namespace WebApi.Apis;

public static class WineApi
{
    public static class EndpointNames   // For easier access of endpoints from tests
    {
        public const string AllWines = nameof(GetAllWines);      // http://localhost:5046/api/wines/all-wines
        public const string WineById = nameof(GetWineById);    // http://localhost:5046/api/wines/wine-by-id?id=1
    }

    public static RouteGroupBuilder RegisterWineApi(this RouteGroupBuilder apiGroup)
    {
        RouteGroupBuilder group = apiGroup.MapGroup("wines");

        group.MapGet("all-wines", GetAllWines)
            .WithDescription("Get a list of all wines.")
            .WithName(EndpointNames.AllWines); ;

        group.MapGet("wine-by-id", GetWineById)
         .WithDescription("Get a single wine.")
         .WithName(EndpointNames.WineById); ;

        return apiGroup;
    }

    // TODO: Change to return Dto
    public static async Task<IEnumerable<Wine>> GetAllWines(
        WineService service,
        CancellationToken ct)
    {
        //var allWines = new Wine[]
        //{
        //new ()
        //{
        //Id = 1,
        //Producer= "Clotilde Davenne",
        //Label = "Brut Extra Crémant de Bourgogne",
        //Vintage = null,
        //AlcoholByVolume = new decimal(12.5),
        //Container = Container.Bottle,
        //Grapes = new List<Blend>()
        //{
        //new Blend(Grape.PinotNoir, 60),
        //new Blend(Grape.Chardonnay, 40),
        //}
        //}
        //};
        var allWines = await service.GetAllWines(ct);
        return allWines;
    }

    public static async Task<Wine?> GetWineById(
        long Id,
        WineService service,
        CancellationToken ct)
    {
        //var wine = new Wine()
        //{
        //Id = 1,
        //Producer = "Clotilde Davenne",
        //Label = "Brut Extra Crémant de Bourgogne",
        //Vintage = null,
        //AlcoholByVolume = new decimal(12.5),
        //Container = Container.Bottle,
        //Grapes = new List<Blend>()
        //{
        //new Blend(Grape.PinotNoir, 60),
        //new Blend(Grape.Chardonnay, 40),
        //}
        //};

        var wine = await service.GetAWine(Id, ct);

        return wine;
    }
}
