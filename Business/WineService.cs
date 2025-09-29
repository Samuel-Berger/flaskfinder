using Dtos;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Business;

public class WineService(FlaskFinderDbContext _dbContext)
{
    public async Task<IEnumerable<WineDto>> GetAllWines(CancellationToken ct)
    {
        var wines = _dbContext.Wines
            .ToList()
            .Select(x => new WineDto(
                x.Id.ToString())
            );
        return wines;
    }

    public async Task<WineDto?> GetAWine(long id, CancellationToken ct)
    {
        var wine = await _dbContext.Wines.SingleOrDefaultAsync(
            x => x.Id == id, ct);

        if (wine == null)
        {
            return null;
        }

        return new WineDto(wine.Id.ToString());
    }
}
