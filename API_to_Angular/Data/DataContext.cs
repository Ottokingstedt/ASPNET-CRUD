using API_to_Angular;
using Microsoft.EntityFrameworkCore;

namespace NbaPlayerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<NbaPlayers> Nbaplayers => Set<NbaPlayers>();
    }
}