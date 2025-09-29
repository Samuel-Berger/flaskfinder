using FlaskFinder;

namespace WebApi.Apis;

public static class WineApi
{
    public static class EndpointNames   // For easier access of endpoints from tests
    {
        public const string GetAllWines = nameof(GetAllWines);      // http://localhost:5046/api/wines/get-all-wines
        public const string GetAWineById = nameof(GetAWineById);    // http://localhost:5046/api/wines/get-a-wine-by-id?id=1
    }

    public static RouteGroupBuilder RegisterWineApi(this RouteGroupBuilder apiGroup)
    {
        RouteGroupBuilder group = apiGroup.MapGroup("wines");

        group.MapGet("get-all-wines", GetAllWines)
            .WithDescription("Get a list of all wines.")
            .WithName(EndpointNames.GetAllWines); ;

        group.MapGet("get-a-wine-by-id", GetAWineById)
         .WithDescription("Get a single wine.")
         .WithName(EndpointNames.GetAWineById); ;

        return apiGroup;
    }

    // TODO: Change to return Dto
    public static async Task<IEnumerable<Wine>> GetAllWines(CancellationToken ct)
    {
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
        return allWines;
    }

    public static async Task<Wine> GetAWineById(
        long Id,
        CancellationToken ct)
    {
        var wine = new Wine()
        {
            Id = 1,
            Producer = "Clotilde Davenne",
            Label = "Brut Extra Crémant de Bourgogne",
            Vintage = null,
            AlcoholByVolume = new decimal(12.5),
            Container = Container.Bottle,
            Grapes = new List<Blend>()
                {
                    new Blend(Grape.PinotNoir, 60),
                    new Blend(Grape.Chardonnay, 40),
                }
        };

        return wine;
    }
}
