using Entities;
using FlaskFinder;
using Microsoft.EntityFrameworkCore;

namespace Business;

public class WineService(FlaskFinderDbContext _dbContext)
{
    public async Task<IEnumerable<WineDto>> GetAllWines(CancellationToken ct)
    {
        var wines = await _dbContext.Wines
           .Select(x => new WineDto(x.Id.ToString()))
           .ToListAsync(ct);

        return wines;
    }

    public async Task<WineDto?> GetAWine(long id, CancellationToken ct)
    {
        var wine = await _dbContext.Wines
           .Where(x => x.Id == id)
           .Select(x => new WineDto(x.Id.ToString()))
           .SingleOrDefaultAsync(ct);

        return wine;
    }
}
