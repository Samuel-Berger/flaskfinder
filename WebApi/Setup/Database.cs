using Microsoft.EntityFrameworkCore;

namespace WebApi.Setup
{
    public class Database(DbContextOptions<Database> options) : DbContext(options)
    {
    }
}
