using Entities;

namespace Business
{
    public class WineManipulation(FlaskFinderDbContext _dbContext)
    {
        public async Task<bool> CreateWine(Wine wineToCreate, CancellationToken ct)
        {
            _dbContext.Add<Wine>(wineToCreate);
            var changes = await _dbContext.SaveChangesAsync(ct);

            if (changes > 0)
            {
                return true;
            }
            return false;
        }
    }
}
