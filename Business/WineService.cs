using Entities;
using FlaskFinder;
using Microsoft.EntityFrameworkCore;

namespace Business;

public class WineService(FlaskFinderDbContext _dbContext)
{
    public async Task<IEnumerable<Wine>> GetAllWines(CancellationToken ct)
    {
        var wines = await _dbContext.Wines.ToListAsync(ct);
        return wines;
    }

    public async Task<Wine?> GetAWine(long id, CancellationToken ct)
    {
        var wine = await _dbContext.Wines.SingleOrDefaultAsync(
            x => x.Id == id, cancellationToken: ct);
        return wine;
    }
}
