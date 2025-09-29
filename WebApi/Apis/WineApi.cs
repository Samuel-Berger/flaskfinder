using Business;
using Dtos;

namespace WebApi.Apis;

public static class WineApi
{
    public static class EndpointNames   // For easier access of endpoints from tests
    {
        public const string AllWines = nameof(GetAllWines);      // http://localhost:5046/api/wines/all-wines
        public const string WineById = nameof(GetWineById);    // http://localhost:5046/api/wines/wine-by-id?id=1
        public const string CreateWine = nameof(CreateWine);    // http://localhost:5046/api/wines/wine-by-id?id=1

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

        //group.MapGet("create-wine", CreateWine)
         //.WithDescription("Create a wine.")
         //.WithName(EndpointNames.CreateWine); ;

        return apiGroup;
    }

    public static async Task<IEnumerable<WineDto>> GetAllWines(
        WineService service,
        CancellationToken ct)
    {
        var allWines = await service.GetAllWines(ct);
        return allWines;
    }

    public static async Task<WineDto?> GetWineById(
        long Id,
        WineService service,
        CancellationToken ct)
    {
        var wine = await service.GetAWine(Id, ct);

        return wine;
    }

    //public static async Task CreateWine(
    //Wine wine,
    //WineManipulation changes,
    //CancellationToken ct)
    //{
    //var status = await changes.CreateWine(wine, ct);

    //return;
    //}
}
